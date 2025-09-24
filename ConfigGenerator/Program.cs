// Decompiled with JetBrains decompiler
// Type: ConfigGenerator.Program
// Assembly: ConfigGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E333375F-E325-44D6-8F8A-127F1A7AB356
// Assembly location: C:\Users\Rafael Mazzoni\Documents\Ideias de Revenda\RetroSix\Free Mu CMS 1.2.3\Launcher Free\Launcher Free\Generator\ConfigGenerator.exe

using System;
using System.Windows.Forms;

namespace ConfigGenerator
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
