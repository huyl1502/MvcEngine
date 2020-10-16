// Decompiled with JetBrains decompiler
// Type: System.Mvc.ITimer
// Assembly: MvcEngine, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: F94F3483-5625-4305-ACF5-74F93F44B4B1
// Assembly location: F:\Project\dll\MvcEngine.dll

namespace System.Mvc
{
  public interface ITimer
  {
    int Delay { get; set; }

    void Start();

    void Stop();

    event EventHandler Tick;
  }
}
