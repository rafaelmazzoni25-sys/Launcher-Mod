using System;

namespace LauncherSuite.Core.Design
{
    public static class ThemeAssetCatalog
    {
        private static readonly ThemeAsset[] DefaultAssets = new ThemeAsset[]
        {
            Create(ThemeKeys.Background, "images/background.png"),
            Create(ThemeKeys.StartButtonIdle, "images/start/idle.png"),
            Create(ThemeKeys.StartButtonHover, "images/start/hover.png"),
            Create(ThemeKeys.StartButtonPressed, "images/start/pressed.png"),
            Create(ThemeKeys.StartButtonDisabled, "images/start/disabled.png"),
            Create(ThemeKeys.ExitButtonIdle, "images/exit/idle.png"),
            Create(ThemeKeys.ExitButtonHover, "images/exit/hover.png"),
            Create(ThemeKeys.ExitButtonPressed, "images/exit/pressed.png"),
            Create(ThemeKeys.SettingsButtonIdle, "images/settings/idle.png"),
            Create(ThemeKeys.SettingsButtonHover, "images/settings/hover.png"),
            Create(ThemeKeys.SettingsButtonPressed, "images/settings/pressed.png"),
            Create(ThemeKeys.WindowModeChecked, "images/windowmode/checked.png"),
            Create(ThemeKeys.WindowModeUnchecked, "images/windowmode/unchecked.png"),
            Create(ThemeKeys.ProgressBar, "images/progress/bar.png"),
            Create(ThemeKeys.ProgressOverlay, "images/progress/overlay.png"),
            Create(ThemeKeys.AcceptButtonIdle, "images/options/accept/idle.png"),
            Create(ThemeKeys.AcceptButtonHover, "images/options/accept/hover.png"),
            Create(ThemeKeys.AcceptButtonPressed, "images/options/accept/pressed.png"),
            Create(ThemeKeys.OptionsBackground, "images/options/background.png"),
        };

        public static ThemeAsset[] CreateDefaultAssets()
        {
            ThemeAsset[] assets = new ThemeAsset[DefaultAssets.Length];
            for (int i = 0; i < DefaultAssets.Length; i++)
            {
                ThemeAsset source = DefaultAssets[i];
                ThemeAsset copy = new ThemeAsset();
                copy.Key = source.Key;
                copy.RelativePath = source.RelativePath;
                assets[i] = copy;
            }

            return assets;
        }

        public static string[] GetRequiredKeys()
        {
            string[] keys = new string[DefaultAssets.Length];
            for (int i = 0; i < DefaultAssets.Length; i++)
            {
                keys[i] = DefaultAssets[i].Key;
            }

            return keys;
        }

        private static ThemeAsset Create(string key, string relativePath)
        {
            ThemeAsset asset = new ThemeAsset();
            asset.Key = key;
            asset.RelativePath = relativePath;
            return asset;
        }
    }
}
