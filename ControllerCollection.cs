// Decompiled with JetBrains decompiler
// Type: System.Mvc.ControllerCollection
// Assembly: MvcEngine, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: F94F3483-5625-4305-ACF5-74F93F44B4B1
// Assembly location: F:\Project\dll\MvcEngine.dll

using System.Collections.Generic;
using System.Reflection;

namespace System.Mvc
{
  public class ControllerCollection : Dictionary<string, Type>
  {
    public ControllerCollection(Assembly assembly)
    {
      foreach (Type type in assembly.GetTypes())
      {
        string lower = type.Name.ToLower();
        if (lower.EndsWith("controller"))
          this.Add(lower.Substring(0, lower.Length - 10), type);
      }
    }

    public Controller CreateController(string name)
    {
      Type type;
      return this.TryGetValue(name.ToLower(), out type) ? (Controller) Activator.CreateInstance(type) : (Controller) null;
    }
  }
}
