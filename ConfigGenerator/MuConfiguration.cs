using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ConfigGenerator
{
    /// <summary>
    /// Encapsulates the serialization logic of the legacy <c>mu.ini</c> file.
    /// </summary>
    public sealed class MuConfiguration
    {
        private static readonly byte[] XorKey = { 77, 252, 207, 171, byte.MaxValue };

        public const string DefaultFileName = "./mu.ini";

        public int SeasonIndex { get; set; }

        public int LanguageIndex { get; set; }

        public string LauncherName { get; set; } = "Mu Launcher";

        public string UpdateUrl { get; set; } = "http://127.0.0.1/update/";

        public string ExecutableName { get; set; } = "main.exe";

        public string PageUrl { get; set; } = "http://127.0.0.1/update/index.php";

        public static MuConfiguration Load(string path = DefaultFileName)
        {
            if (!File.Exists(path))
            {
                return new MuConfiguration();
            }

            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var reader = new BinaryReader(stream, Encoding.UTF8, leaveOpen: false);

            var config = new MuConfiguration
            {
                SeasonIndex = reader.ReadInt32(),
                LanguageIndex = reader.ReadInt32()
            };

            var encryptedBytes = reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position));
            var decrypted = ApplyXor(encryptedBytes);
            var parts = Encoding.UTF8.GetString(decrypted).Split('|');

            config.LauncherName = parts.ElementAtOrDefault(0) ?? config.LauncherName;
            config.UpdateUrl = parts.ElementAtOrDefault(1) ?? config.UpdateUrl;
            config.ExecutableName = parts.ElementAtOrDefault(2) ?? config.ExecutableName;
            config.PageUrl = parts.ElementAtOrDefault(3) ?? config.PageUrl;

            return config;
        }

        public void Save(string path = DefaultFileName)
        {
            using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            using var writer = new BinaryWriter(stream, Encoding.UTF8, leaveOpen: false);

            writer.Write(SeasonIndex);
            writer.Write(LanguageIndex);

            var payload = string.Join("|", LauncherName, UpdateUrl, ExecutableName, PageUrl);
            var buffer = Encoding.UTF8.GetBytes(payload);
            var encrypted = ApplyXor(buffer);

            writer.Write(encrypted);
        }

        private static byte[] ApplyXor(byte[] buffer)
        {
            var result = new byte[buffer.Length];
            for (var i = 0; i < buffer.Length; i++)
            {
                result[i] = (byte)(buffer[i] ^ XorKey[i % XorKey.Length]);
            }

            return result;
        }
    }
}
