// Decompiled with JetBrains decompiler
// Type: System.Mvc.Timer
// Assembly: MvcEngine, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: F94F3483-5625-4305-ACF5-74F93F44B4B1
// Assembly location: F:\Project\dll\MvcEngine.dll

using System.Threading;

namespace System.Mvc
{
  public class Timer : IDisposable, ITimer
  {
    private Thread _thread;

    public void Dispose() => this.Stop();

    public void Stop() => this._thread.Abort();

    public void Start() => this._thread.Start();

    public Timer(int interval)
    {
      Timer timer = this;
      this.Delay = interval;
      this._thread = new Thread((ThreadStart) (() =>
      {
        while (true)
        {
          Thread.Sleep(interval);
          EventHandler tick = timer.Tick;
          if (tick != null)
            tick((object) timer, (EventArgs) null);
        }
      }));
    }

    protected virtual void CallEvent(Action<int> e, int value) => e(value);

    public event EventHandler Tick;

    public int Delay { get; set; }
  }
}
