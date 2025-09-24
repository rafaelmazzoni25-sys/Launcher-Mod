using System;
using System.Drawing;
using Launcher;
using LauncherSuite.Core.Design;

namespace Launcher.Design
{
    internal sealed class ThemeSurfaceBinding
    {
        public string Key { get; private set; }

        public Action<MainForm, Image> Apply { get; private set; }

        private ThemeSurfaceBinding(string key, Action<MainForm, Image> apply)
        {
            this.Key = key;
            this.Apply = apply;
        }

        public static ThemeSurfaceBinding[] CreateMainFormBindings()
        {
            return new ThemeSurfaceBinding[]
            {
                new ThemeSurfaceBinding(ThemeKeys.Background, delegate(MainForm form, Image image) { form.BackgroundImage = image; }),
                new ThemeSurfaceBinding(ThemeKeys.StartButtonDisabled, delegate(MainForm form, Image image) { form.StartButton.BackgroundImage = image; }),
                new ThemeSurfaceBinding(ThemeKeys.ExitButtonIdle, delegate(MainForm form, Image image) { form.ExitButton.BackgroundImage = image; }),
                new ThemeSurfaceBinding(ThemeKeys.SettingsButtonIdle, delegate(MainForm form, Image image) { form.pictureBox3.BackgroundImage = image; }),
                new ThemeSurfaceBinding(ThemeKeys.WindowModeUnchecked, delegate(MainForm form, Image image) { form.pictureBox4.BackgroundImage = image; }),
                new ThemeSurfaceBinding(ThemeKeys.ProgressBar, delegate(MainForm form, Image image) { form.pictureBox5.BackgroundImage = image; }),
                new ThemeSurfaceBinding(ThemeKeys.ProgressOverlay, delegate(MainForm form, Image image) { form.pictureBox6.Image = image; }),
            };
        }
    }
}
