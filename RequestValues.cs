// Decompiled with JetBrains decompiler
// Type: System.Mvc.RequestValues
// Assembly: MvcEngine, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: F94F3483-5625-4305-ACF5-74F93F44B4B1
// Assembly location: F:\Project\dll\MvcEngine.dll

using System.Collections;

namespace System.Mvc
{
  public class RequestValues : ArrayList
  {
    public static implicit operator RequestValues(object[] values)
    {
      RequestValues requestValues = new RequestValues();
      requestValues.AddRange((ICollection) values);
      return requestValues;
    }
  }
}
