using System;
using System.IO;
using LauncherSuite.Core.Configuration;
using LauncherSuite.Core.Design;
using LauncherSuite.Core.Updates;

namespace LauncherSuite.Core.Build
{
    public sealed class BuildPipeline
    {
        private readonly UpdateManifestBuilder _manifestBuilder;

        public BuildPipeline(UpdateManifestBuilder manifestBuilder)
        {
            _manifestBuilder = manifestBuilder ?? throw new ArgumentNullException(nameof(manifestBuilder));
        }

        public BuildPipelineResult Run(BuildPipelineOptions options, IProgress<ManifestProgress>? manifestProgress = null)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (options.Configuration == null)
            {
                throw new ArgumentException("A configuration instance must be provided.", nameof(options));
            }

            if (string.IsNullOrWhiteSpace(options.UpdateSourcePath))
            {
                throw new ArgumentException("The update source path must be provided.", nameof(options));
            }

            var configurationPath = options.ConfigurationPath ?? MuConfiguration.DefaultFileName;
            options.Configuration.Save(configurationPath);

            var updateOutput = options.UpdateOutputDirectory ?? Path.Combine(Environment.CurrentDirectory, "update");
            var manifestResult = _manifestBuilder.Build(options.UpdateSourcePath, updateOutput, manifestProgress);
            var manifestPath = options.ManifestPath ?? Path.Combine(updateOutput, "update.txt");
            File.WriteAllText(manifestPath, manifestResult.ToManifestText());

            string? themeManifestPath = null;
            ThemeManifest? themeManifest = null;
            if (options.CreateThemePackage)
            {
                var themeDirectory = options.ThemeOutputDirectory;
                if (string.IsNullOrWhiteSpace(themeDirectory))
                {
                    throw new ArgumentException("A theme output directory must be provided when CreateThemePackage is enabled.", nameof(options));
                }

                themeManifest = options.ThemeManifest ?? ThemeManifest.CreateDefault(options.ThemeName ?? ThemeKeys.DefaultThemeName);
                themeManifestPath = PrepareThemeDirectory(themeDirectory, themeManifest, options.IncludeDefaultThemeAssets, options.DefaultThemeExporter);
            }

            return new BuildPipelineResult(configurationPath, manifestPath, themeManifestPath, manifestResult, themeManifest);
        }

        private static string PrepareThemeDirectory(string targetDirectory, ThemeManifest manifest, bool includeDefaults, Func<string, ThemeManifest, string>? exporter)
        {
            if (includeDefaults)
            {
                if (exporter == null)
                {
                    throw new InvalidOperationException("A default theme exporter must be provided to include default assets.");
                }

                return exporter(targetDirectory, manifest);
            }

            Directory.CreateDirectory(targetDirectory);
            var assets = manifest.Assets ?? Array.Empty<ThemeAsset>();
            foreach (var asset in assets)
            {
                var assetPath = Path.Combine(targetDirectory, asset.RelativePath);
                var directory = Path.GetDirectoryName(assetPath);
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }
            }

            manifest.Save(targetDirectory);
            return Path.Combine(targetDirectory, ThemeManifest.ManifestFileName);
        }
    }

    public sealed class BuildPipelineOptions
    {
        public MuConfiguration? Configuration { get; set; }

        public string? ConfigurationPath { get; set; }

        public string UpdateSourcePath { get; set; } = string.Empty;

        public string? UpdateOutputDirectory { get; set; }

        public string? ManifestPath { get; set; }

        public bool CreateThemePackage { get; set; }

        public string? ThemeName { get; set; }

        public string? ThemeOutputDirectory { get; set; }

        public ThemeManifest? ThemeManifest { get; set; }

        public bool IncludeDefaultThemeAssets { get; set; }

        public Func<string, ThemeManifest, string>? DefaultThemeExporter { get; set; }
    }

    public sealed record BuildPipelineResult(
        string ConfigurationPath,
        string ManifestPath,
        string? ThemeManifestPath,
        ManifestBuildResult Manifest,
        ThemeManifest? ThemeManifest);
}
