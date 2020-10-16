// Decompiled with JetBrains decompiler
// Type: System.Mvc.Engine
// Assembly: MvcEngine, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: F94F3483-5625-4305-ACF5-74F93F44B4B1
// Assembly location: F:\Project\dll\MvcEngine.dll

using System.Reflection;

namespace System.Mvc
{
  public class Engine
  {
    protected static Assembly _assembly;
    protected static string _assemblyName;
    protected static ControllerCollection _controllerMap;
    public static Action<ActionResult> ValidateActionResult;

    public static Session Session { get; private set; } = new Session();

    public static T GetController<T>(string name) where T : Controller => (T) Engine._controllerMap.CreateController(name);

    public static RequestContext RequestContext { get; private set; }

    public static void Register(object app, Action<ActionResult> viewValidateCallback) => Engine.Register(app, (string) null, viewValidateCallback);

    public static void Register(
      object app,
      string assemblyName,
      Action<ActionResult> viewValidateCallback)
    {
      Engine._assembly = app.GetType().Assembly;
      Engine._assemblyName = assemblyName ?? Engine._assembly.GetName().Name;
      Engine._controllerMap = new ControllerCollection(Engine._assembly);
      Engine.ValidateActionResult = viewValidateCallback;
    }

    public static T CreateObject<T>(string name) => (T) Engine._assembly.CreateInstance(Engine._assemblyName + "." + name);

    public static void Execute(string url, params object[] values)
    {
      RequestContext request = new RequestContext(url);
      foreach (object obj in values)
        request.Values.Add(obj);
      Engine.Execute(request);
    }

    public static void Execute(RequestContext request)
    {
      Engine.RequestContext = request;
      Engine.GetController<Controller>(request.ControllerName)?.Execute(request, (Action<ActionResult>) null);
    }
  }
}
