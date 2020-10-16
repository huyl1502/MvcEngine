// Decompiled with JetBrains decompiler
// Type: System.Mvc.ActionResult
// Assembly: MvcEngine, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: F94F3483-5625-4305-ACF5-74F93F44B4B1
// Assembly location: F:\Project\dll\MvcEngine.dll

namespace System.Mvc
{
  public class ActionResult
  {
    public IView View { get; set; }

    public Controller Controller { get; set; }

    public bool Handled { get; set; }
  }
}
