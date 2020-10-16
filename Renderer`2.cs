// Decompiled with JetBrains decompiler
// Type: System.Mvc.Renderer`2
// Assembly: MvcEngine, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: F94F3483-5625-4305-ACF5-74F93F44B4B1
// Assembly location: F:\Project\dll\MvcEngine.dll

namespace System.Mvc
{
  public class Renderer<TView, TModel> : IView, IRenderer where TView : new()
  {
    public virtual object GetResult() => (object) this.MainContent;

    protected virtual TView CreateMainContent() => new TView();

    public TView MainContent { get; protected set; }

    public TModel Model { get; private set; }

    public ViewDataDictionary ViewBag { get; private set; }

    public Controller Controller { get; private set; }

    public virtual void Render(Controller controller) => this.RenderCore(this.Controller = controller, this.ViewBag = controller.ViewData, this.Model = (TModel) controller.ViewData.Model, this.MainContent = this.CreateMainContent());

    protected virtual void RenderCore(
      Controller controller,
      ViewDataDictionary viewData,
      TModel model,
      TView mainContent)
    {
    }
  }
}
