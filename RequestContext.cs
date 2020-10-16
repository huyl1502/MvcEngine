// Decompiled with JetBrains decompiler
// Type: System.Mvc.RequestContext
// Assembly: MvcEngine, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: F94F3483-5625-4305-ACF5-74F93F44B4B1
// Assembly location: F:\Project\dll\MvcEngine.dll

namespace System.Mvc
{
  public class RequestContext
  {
    public RequestContext()
    {
    }

    public RequestContext(string controllerName, string actionName)
    {
      this.ControllerName = controllerName;
      this.ActionName = actionName;
    }

    public RequestContext(string url)
    {
      string str1 = url;
      char[] chArray = new char[1]{ '/' };
      foreach (string str2 in str1.Split(chArray))
      {
        if (!(str2 == string.Empty))
        {
          if (this.ControllerName == null)
            this.ControllerName = str2;
          else if (this.ActionName == null)
            this.ActionName = str2;
          else
            this.Values.Add((object) str2);
        }
      }
    }

    public string ControllerName { get; set; }

    public string ActionName { get; set; }

    public RequestValues Values { get; set; } = new RequestValues();
  }
}
