// Decompiled with JetBrains decompiler
// Type: Launcher.Exile.LauncherOptions
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 232F895E-1583-4AAE-8C54-19D96214944A
// Assembly location: C:\Users\Rafael Mazzoni\Documents\Ideias de Revenda\RetroSix\Free Mu CMS 1.2.3\Launcher Free\Launcher Free\Client\Launcher.exe

using System;
using Launcher.Design;

namespace Launcher.Exile
{
  internal class LauncherOptions
  {
    public static int m_DevModeIndex = 0;
    public static int m_WindowMode = 0;
    public static string m_ID = string.Empty;
    public static string m_Theme = ThemeKeys.DefaultThemeName;
    private static readonly string m_FileName = "LauncherOption.if";

    public static void GetValue()
    {
      LauncherOptions.m_Theme = ThemeKeys.DefaultThemeName;
      try
      {
        foreach (string readAllLine in System.IO.File.ReadAllLines(LauncherOptions.m_FileName))
        {
          if (readAllLine.Contains("DevModeIndex:"))
            LauncherOptions.m_DevModeIndex = Convert.ToInt32(readAllLine.Split(':')[1]);
          if (readAllLine.Contains("WindowMode:"))
            LauncherOptions.m_WindowMode = Convert.ToInt32(readAllLine.Split(':')[1]);
          if (readAllLine.Contains("ID:"))
            LauncherOptions.m_ID = readAllLine.Split(':')[1];
          if (readAllLine.Contains("Theme:"))
          {
            string[] parts = readAllLine.Split(new char[1]{ ':' }, 2);
            if (parts.Length == 2)
              LauncherOptions.m_Theme = parts[1];
          }
        }
      }
      catch
      {
      }
    }

    public static void SetValue(int DevModeIndex, int WindowMode, string ID)
    {
      LauncherOptions.InternalSetValue(DevModeIndex, WindowMode, ID, LauncherOptions.m_Theme);
    }

    public static void SetTheme(string themeName)
    {
      if (string.IsNullOrEmpty(themeName))
        themeName = ThemeKeys.DefaultThemeName;
      LauncherOptions.m_Theme = themeName;
      LauncherOptions.InternalSetValue(LauncherOptions.m_DevModeIndex, LauncherOptions.m_WindowMode, LauncherOptions.m_ID, LauncherOptions.m_Theme);
    }

    private static void InternalSetValue(int devModeIndex, int windowMode, string id, string theme)
    {
      try
      {
        LauncherOptions.m_DevModeIndex = devModeIndex;
        LauncherOptions.m_WindowMode = windowMode;
        LauncherOptions.m_ID = id;
        LauncherOptions.m_Theme = string.IsNullOrEmpty(theme) ? ThemeKeys.DefaultThemeName : theme;
        string[] contents = new string[4]
        {
          string.Format("DevModeIndex:{0}", (object) devModeIndex),
          string.Format("WindowMode:{0}", (object) windowMode),
          string.Format("ID:{0}", (object) id),
          string.Format("Theme:{0}", (object) LauncherOptions.m_Theme)
        };
        System.IO.File.WriteAllLines(LauncherOptions.m_FileName, contents);
      }
      catch
      {
      }
    }
  }
}
