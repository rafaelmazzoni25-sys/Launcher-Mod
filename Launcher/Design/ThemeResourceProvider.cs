using System.Drawing;
using Launcher.Properties;

namespace Launcher.Design
{
    internal static class ThemeResourceProvider
    {
        public static Image GetBuiltin(string key)
        {
            if (ThemeKeys.EqualsName(key, ThemeKeys.Background))
            {
                return Clone(Resources.BITMAP129_1);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.StartButtonIdle))
            {
                return Clone(Resources.start_1);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.StartButtonHover))
            {
                return Clone(Resources.start_2);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.StartButtonPressed))
            {
                return Clone(Resources.start_3);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.StartButtonDisabled))
            {
                return Clone(Resources.start_4);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.ExitButtonIdle))
            {
                return Clone(Resources.exit_1);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.ExitButtonHover))
            {
                return Clone(Resources.exit_2);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.ExitButtonPressed))
            {
                return Clone(Resources.exit_3);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.SettingsButtonIdle))
            {
                return Clone(Resources.setting_1);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.SettingsButtonHover))
            {
                return Clone(Resources.setting_2);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.SettingsButtonPressed))
            {
                return Clone(Resources.setting_3);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.WindowModeChecked))
            {
                return Clone(Resources.windowmode);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.WindowModeUnchecked))
            {
                return Clone(Resources.windowmode_uncheck);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.ProgressBar))
            {
                return Clone(Resources.BITMAP154_1);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.ProgressOverlay))
            {
                return Clone(Resources.BITMAP155_1);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.AcceptButtonIdle))
            {
                return Clone(Resources.accept_1);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.AcceptButtonHover))
            {
                return Clone(Resources.accept_2);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.AcceptButtonPressed))
            {
                return Clone(Resources.accept_3);
            }

            if (ThemeKeys.EqualsName(key, ThemeKeys.OptionsBackground))
            {
                return Clone(Resources.setting_back);
            }

            return null;
        }

        private static Image Clone(Image image)
        {
            if (image == null)
            {
                return null;
            }

            return new Bitmap(image);
        }
    }
}
