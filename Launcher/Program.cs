// Decompiled with JetBrains decompiler
// Type: Launcher.Program
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 232F895E-1583-4AAE-8C54-19D96214944A
// Assembly location: C:\Users\Rafael Mazzoni\Documents\Ideias de Revenda\RetroSix\Free Mu CMS 1.2.3\Launcher Free\Launcher Free\Client\Launcher.exe

using System;
using System.Windows.Forms;

namespace Launcher
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new MainForm());
    }
  }
}
