using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Launcher;
using LauncherSuite.Core.Design;

namespace Launcher.Design
{
    internal static class ThemeManager
    {
        private const string ThemesFolder = "Themes";

        public static string GetThemeDirectory(string themeName)
        {
            if (string.IsNullOrEmpty(themeName))
            {
                themeName = ThemeKeys.DefaultThemeName;
            }

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (string.IsNullOrEmpty(baseDirectory))
            {
                baseDirectory = Environment.CurrentDirectory;
            }

            return Path.Combine(baseDirectory, ThemesFolder, themeName);
        }

        public static ThemeManifest EnsureDefaultThemePackage()
        {
            string directory = GetThemeDirectory(ThemeKeys.DefaultThemeName);
            ThemeManifest manifest = ThemeManifest.Load(directory);
            if (manifest != null)
            {
                return manifest;
            }

            manifest = ThemeManifest.CreateDefault(ThemeKeys.DefaultThemeName);
            ExportBuiltinAssets(directory, manifest);
            return manifest;
        }

        public static bool TryApplyTheme(MainForm form, string themeName, out string error)
        {
            error = null;
            try
            {
                ThemeResources.Reset();
                string directory = GetThemeDirectory(themeName);
                ThemeManifest manifest = ThemeManifest.Load(directory);
                if (manifest == null)
                {
                    error = "Theme manifest not found.";
                    return false;
                }

                string[] requiredKeys = ThemeAssetCatalog.GetRequiredKeys();
                for (int i = 0; i < requiredKeys.Length; i++)
                {
                    ThemeAsset asset = manifest.GetAsset(requiredKeys[i]);
                    if (asset == null)
                    {
                        error = "Missing asset entry: " + requiredKeys[i];
                        return false;
                    }

                    string assetPath = Path.Combine(directory, asset.RelativePath);
                    if (!File.Exists(assetPath))
                    {
                        error = "Asset file not found: " + assetPath;
                        return false;
                    }

                    using (Image image = LoadImage(assetPath))
                    {
                        ThemeResources.Set(asset.Key, image);
                    }
                }

                ThemeSurfaceBinding[] bindings = ThemeSurfaceBinding.CreateMainFormBindings();
                for (int j = 0; j < bindings.Length; j++)
                {
                    ThemeSurfaceBinding binding = bindings[j];
                    Image image = ThemeResources.Get(binding.Key);
                    if (image != null)
                    {
                        binding.Apply(form, image);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public static ThemeManifest ExportBuiltinAssets(string directory, ThemeManifest manifest)
        {
            Directory.CreateDirectory(directory);
            if (manifest == null)
            {
                manifest = ThemeManifest.CreateDefault(ThemeKeys.DefaultThemeName);
            }

            ThemeAsset[] assets = manifest.Assets;
            if (assets == null)
            {
                assets = ThemeAssetCatalog.CreateDefaultAssets();
                manifest.Assets = assets;
            }

            for (int i = 0; i < assets.Length; i++)
            {
                ThemeAsset asset = assets[i];
                string target = Path.Combine(directory, asset.RelativePath);
                string parent = Path.GetDirectoryName(target);
                if (!string.IsNullOrEmpty(parent))
                {
                    Directory.CreateDirectory(parent);
                }

                using (Image image = ThemeResourceProvider.GetBuiltin(asset.Key))
                {
                    if (image == null)
                    {
                        continue;
                    }

                    using (Bitmap copy = new Bitmap(image))
                    {
                        copy.Save(target, ImageFormat.Png);
                    }
                }
            }

            manifest.Save(directory);
            return manifest;
        }

        private static Image LoadImage(string filePath)
        {
            byte[] buffer = File.ReadAllBytes(filePath);
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                return Image.FromStream(stream);
            }
        }
    }
}
