using System;

namespace LauncherSuite.Core.Design
{
    public static class ThemeKeys
    {
        public const string DefaultThemeName = "Default";
        public const string Background = "Background";
        public const string StartButtonIdle = "StartButton.Idle";
        public const string StartButtonHover = "StartButton.Hover";
        public const string StartButtonPressed = "StartButton.Pressed";
        public const string StartButtonDisabled = "StartButton.Disabled";
        public const string ExitButtonIdle = "ExitButton.Idle";
        public const string ExitButtonHover = "ExitButton.Hover";
        public const string ExitButtonPressed = "ExitButton.Pressed";
        public const string SettingsButtonIdle = "SettingsButton.Idle";
        public const string SettingsButtonHover = "SettingsButton.Hover";
        public const string SettingsButtonPressed = "SettingsButton.Pressed";
        public const string WindowModeChecked = "WindowMode.Checked";
        public const string WindowModeUnchecked = "WindowMode.Unchecked";
        public const string ProgressBar = "Progress.Bar";
        public const string ProgressOverlay = "Progress.Overlay";
        public const string AcceptButtonIdle = "AcceptButton.Idle";
        public const string AcceptButtonHover = "AcceptButton.Hover";
        public const string AcceptButtonPressed = "AcceptButton.Pressed";
        public const string OptionsBackground = "Options.Background";

        public static bool EqualsName(string left, string right)
        {
            return string.Equals(left, right, StringComparison.OrdinalIgnoreCase);
        }
    }
}
