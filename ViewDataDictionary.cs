// Decompiled with JetBrains decompiler
// Type: System.Mvc.ViewDataDictionary
// Assembly: MvcEngine, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: F94F3483-5625-4305-ACF5-74F93F44B4B1
// Assembly location: F:\Project\dll\MvcEngine.dll

namespace System.Mvc
{
  public class ViewDataDictionary : Session
  {
    public object Model { get; set; }

    public void SetValue<T>(object value) => this[typeof (T).Name] = value;

    public object GetValue<T>() => this[typeof (T).Name];
  }
}
