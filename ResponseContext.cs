// Decompiled with JetBrains decompiler
// Type: System.Mvc.ResponseContext
// Assembly: MvcEngine, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: F94F3483-5625-4305-ACF5-74F93F44B4B1
// Assembly location: F:\Project\dll\MvcEngine.dll

using System.Collections;

namespace System.Mvc
{
  public class ResponseContext : RequestContext
  {
    public ResponseContext()
    {
    }

    public ResponseContext(RequestContext request)
      : base(request.ControllerName, request.ActionName)
    {
    }

    public ResponseContext(string url, params object[] values)
      : base(url)
      => this.Values.AddRange((ICollection) values);
  }
}
