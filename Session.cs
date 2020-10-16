// Decompiled with JetBrains decompiler
// Type: System.Mvc.Session
// Assembly: MvcEngine, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: F94F3483-5625-4305-ACF5-74F93F44B4B1
// Assembly location: F:\Project\dll\MvcEngine.dll

using System.Collections.Generic;

namespace System.Mvc
{
  public class Session
  {
    private Dictionary<string, object> map = new Dictionary<string, object>();

    public object this[string key]
    {
      get
      {
        object obj;
        this.map.TryGetValue(key, out obj);
        return obj;
      }
      set
      {
        if (this.map.ContainsKey(key))
          this.map[key] = value;
        else
          this.map.Add(key, value);
      }
    }

    public void Abandon() => this.map.Clear();
  }
}
