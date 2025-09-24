using System;
using System.IO;
using System.Xml.Serialization;

namespace Launcher.Design
{
    [Serializable]
    public sealed class ThemeManifest
    {
        public const string ManifestFileName = "theme.xml";

        public string Name { get; set; }

        public string Author { get; set; }

        public string Version { get; set; }

        public string Description { get; set; }

        public string SeasonCompatibility { get; set; }

        [XmlArrayItem("Asset")]
        public ThemeAsset[] Assets { get; set; }

        public ThemeManifest()
        {
            this.Name = "Default Theme";
            this.Author = "Unknown";
            this.Version = "1.0.0";
            this.Description = string.Empty;
            this.SeasonCompatibility = "Any";
            this.Assets = new ThemeAsset[0];
        }

        public ThemeAsset GetAsset(string key)
        {
            if (this.Assets == null)
            {
                return null;
            }

            for (int index = 0; index < this.Assets.Length; index++)
            {
                ThemeAsset asset = this.Assets[index];
                if (asset != null && ThemeKeys.EqualsName(asset.Key, key))
                {
                    return asset;
                }
            }

            return null;
        }

        public void Save(string directoryPath)
        {
            Directory.CreateDirectory(directoryPath);
            string manifestPath = Path.Combine(directoryPath, ManifestFileName);
            XmlSerializer serializer = new XmlSerializer(typeof(ThemeManifest));
            using (FileStream stream = new FileStream(manifestPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                serializer.Serialize(stream, this);
            }
        }

        public static ThemeManifest Load(string directoryPath)
        {
            string manifestPath = Path.Combine(directoryPath, ManifestFileName);
            if (!File.Exists(manifestPath))
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(ThemeManifest));
            using (FileStream stream = new FileStream(manifestPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return (ThemeManifest)serializer.Deserialize(stream);
            }
        }

        public static ThemeManifest CreateDefault(string name)
        {
            ThemeManifest manifest = new ThemeManifest();
            if (!string.IsNullOrEmpty(name))
            {
                manifest.Name = name;
            }

            manifest.Assets = ThemeAssetCatalog.CreateDefaultAssets();
            return manifest;
        }
    }

    [Serializable]
    public sealed class ThemeAsset
    {
        [XmlAttribute]
        public string Key { get; set; }

        [XmlAttribute]
        public string RelativePath { get; set; }

        public ThemeAsset()
        {
            this.Key = string.Empty;
            this.RelativePath = string.Empty;
        }
    }
}
