// Decompiled with JetBrains decompiler
// Type: System.Mvc.Controller
// Assembly: MvcEngine, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: F94F3483-5625-4305-ACF5-74F93F44B4B1
// Assembly location: F:\Project\dll\MvcEngine.dll

using System.Reflection;

namespace System.Mvc
{
  public class Controller
  {
    public ViewDataDictionary ViewData { get; private set; } = new ViewDataDictionary();

    public RequestContext RequestContext { get; set; }

    public string ControllerName
    {
      get
      {
        string name = this.GetType().Name;
        return name.Substring(0, name.Length - 10);
      }
    }

    public MethodInfo GetMethod(string name)
    {
      name = name.ToLower();
      foreach (MethodInfo method in this.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public))
      {
        if (method.Name.ToLower() == name)
          return method;
      }
      return (MethodInfo) null;
    }

    public MethodInfo GetMethod(string name, object[] values)
    {
      MethodInfo methodInfo = (MethodInfo) null;
      name = name.ToLower();
      foreach (MethodInfo method in this.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public))
      {
        if (!(method.Name.ToLower() != name))
        {
          ParameterInfo[] parameters = method.GetParameters();
          if (parameters.Length == values.Length)
          {
            methodInfo = method;
            for (int index = 0; index < values.Length; ++index)
            {
              Type parameterType = parameters[index].ParameterType;
              object obj = values[index];
              if (obj == null)
              {
                if (parameterType.IsValueType)
                {
                  methodInfo = (MethodInfo) null;
                  break;
                }
              }
              else if (obj.GetType() != parameterType)
              {
                try
                {
                  values[index] = Convert.ChangeType(obj, parameterType);
                }
                catch
                {
                  methodInfo = (MethodInfo) null;
                  break;
                }
              }
            }
            if (methodInfo != (MethodInfo) null)
              break;
          }
        }
      }
      return methodInfo;
    }

    protected virtual T GetActionResult<T>(
      string actionName,
      RequestValues values,
      Action<T> execute)
    {
      object[] array = values.ToArray();
      MethodInfo method = this.GetMethod(actionName, array);
      if (method == (MethodInfo) null)
        return default (T);
      this.RequestContext.ActionName = method.Name;
      T obj = (T) method.Invoke((object) this, array);
      if (execute != null)
        execute(obj);
      return obj;
    }

    protected virtual void ExecuteCore(
      string actionName,
      RequestValues values,
      Action<ActionResult> callBack)
    {
      if (this.RequestContext == null)
        this.RequestContext = new RequestContext();
      this.RequestContext.ActionName = actionName;
      try
      {
        this.GetActionResult<ActionResult>(actionName, values, (Action<ActionResult>) (result =>
        {
          if (result.Handled)
            return;
          if (callBack == null)
            callBack = Engine.ValidateActionResult;
          Action<ActionResult> action = callBack;
          if (action != null)
            action(result);
        }));
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
      }
    }

    public void Execute(RequestContext requestContext, Action<ActionResult> callBack)
    {
      this.RequestContext = requestContext;
      this.ExecuteCore(requestContext.ActionName ?? "Default", requestContext.Values, callBack);
    }

    public void Execute(string actionName, params object[] values) => this.ExecuteCore(actionName, (RequestValues) values, (Action<ActionResult>) null);

    protected virtual void OnExecuteError(Exception e)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.BackgroundColor = ConsoleColor.Gray;
      Console.WriteLine((object) e);
      Console.ResetColor();
    }

    protected ActionResult View(string name, object model) => this.View(Engine.CreateObject<IView>(name), model);

    protected ActionResult View(object model) => this.View(Engine.CreateObject<IView>("Views." + this.ControllerName + "." + this.RequestContext.ActionName), model);

    protected virtual ActionResult View(IView view, object model)
    {
      this.ViewData.Model = model;
      if (!(view is IAsyncView))
        view.Render(this);
      return new ActionResult()
      {
        View = view,
        Controller = this
      };
    }

    protected ActionResult View() => this.View((object) null);

    protected ActionResult RedirectToAction(string actionName)
    {
      ActionResult res = new ActionResult()
      {
        Handled = true
      };
      this.ExecuteCore(actionName, new RequestValues(), (Action<ActionResult>) (result => res = result));
      return res;
    }

    protected ActionResult Redirect(string url)
    {
      Engine.Execute(url);
      return new ActionResult() { Handled = true };
    }

    public virtual ActionResult Done() => new ActionResult()
    {
      Handled = true
    };
  }
}
