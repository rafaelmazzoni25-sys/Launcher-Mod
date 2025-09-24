// Decompiled with JetBrains decompiler
// Type: Launcher.Exile.ListProcessor
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 232F895E-1583-4AAE-8C54-19D96214944A
// Assembly location: C:\Users\Rafael Mazzoni\Documents\Ideias de Revenda\RetroSix\Free Mu CMS 1.2.3\Launcher Free\Launcher Free\Client\Launcher.exe

namespace Launcher.Exile
{
  internal class ListProcessor
  {
    public static void AddFile(string File) => Globals.Files.Add(new Globals.File()
    {
      Name = File.Split(';')[0],
      Hash = File.Split(';')[1]
    });
  }
}
