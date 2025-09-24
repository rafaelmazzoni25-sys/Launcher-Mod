using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cyclic.Redundancy.Check;

namespace Update.Maker
{
    public sealed class UpdateManifestBuilder
    {
        private readonly CRC _crc = new CRC();

        public ManifestBuildResult Build(string sourcePath, string outputDirectory, IProgress<ManifestProgress>? progress = null)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                throw new ArgumentException("Source path must be provided.", nameof(sourcePath));
            }

            var absoluteSource = Path.GetFullPath(sourcePath);
            var files = Directory.EnumerateFiles(absoluteSource, "*", SearchOption.AllDirectories).ToList();

            Directory.CreateDirectory(outputDirectory);

            var entries = new List<UpdateManifestEntry>(files.Count);
            for (var index = 0; index < files.Count; index++)
            {
                var file = files[index];
                var entry = CreateEntry(absoluteSource, outputDirectory, file);
                entries.Add(entry);
                progress?.Report(new ManifestProgress(index + 1, files.Count, entry));
            }

            return new ManifestBuildResult(entries);
        }

        private UpdateManifestEntry CreateEntry(string sourceRoot, string outputDirectory, string file)
        {
            var relativePath = Path.GetRelativePath(sourceRoot, file);
            var normalizedRelativePath = relativePath.Replace("\\", "/");
            var destinationPath = Path.Combine(outputDirectory, relativePath);
            var destinationDirectory = Path.GetDirectoryName(destinationPath);

            if (!string.IsNullOrEmpty(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            File.Copy(file, destinationPath, true);

            return new UpdateManifestEntry(
                normalizedRelativePath,
                ComputeHash(file),
                new FileInfo(file).Length);
        }

        private string ComputeHash(string path)
        {
            using var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            var hash = _crc.ComputeHash(stream);
            return string.Concat(hash.Select(b => b.ToString("X2")));
        }
    }

    public sealed record UpdateManifestEntry(string RelativePath, string Hash, long Size)
    {
        public string ManifestPath => RelativePath + ".rar";

        public string ToManifestLine() => string.Join(";", ManifestPath, Hash, Size);
    }

    public readonly record struct ManifestProgress(int Processed, int Total, UpdateManifestEntry Entry)
    {
        public int Percentage => Total == 0 ? 0 : (int)Math.Round((double)Processed / Total * 100, MidpointRounding.AwayFromZero);
    }

    public sealed record ManifestBuildResult(IReadOnlyList<UpdateManifestEntry> Entries)
    {
        public string ToManifestText()
        {
            if (Entries.Count == 0)
            {
                return string.Empty;
            }

            return string.Join(Environment.NewLine, Entries.Select(entry => entry.ToManifestLine())) + Environment.NewLine;
        }
    }
}
