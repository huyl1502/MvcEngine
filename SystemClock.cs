// Decompiled with JetBrains decompiler
// Type: System.Mvc.SystemClock
// Assembly: MvcEngine, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: F94F3483-5625-4305-ACF5-74F93F44B4B1
// Assembly location: F:\Project\dll\MvcEngine.dll

namespace System.Mvc
{
  public class SystemClock : IDisposable
  {
    protected virtual ITimer CreateTimer() => (ITimer) new Timer(100);

    public event Action<int> Milliseconds;

    public event Action<int> Seconds;

    public event Action<int> Minutes;

    public event Action<int> Hours;

    public event Action<int> Days;

    public SystemClock()
    {
      int ticks = 0;
      int secs = 0;
      int mins = 0;
      int hours = 0;
      int days = 0;
      ITimer timer = this.CreateTimer();
      int interval = timer.Delay;
      timer.Tick += (EventHandler) ((_param1, _param2) =>
      {
        ticks += interval;
        Action<int> milliseconds = this.Milliseconds;
        if (milliseconds != null)
          milliseconds(ticks);
        if (ticks < 1000)
          return;
        ++secs;
        ticks = 0;
        Action<int> seconds = this.Seconds;
        if (seconds != null)
          seconds(secs);
        if (secs == 60)
        {
          ++mins;
          secs = 0;
          Action<int> minutes = this.Minutes;
          if (minutes != null)
            minutes(mins);
          if (mins == 60)
          {
            ++hours;
            mins = 0;
            Action<int> hours1 = this.Hours;
            if (hours1 != null)
              hours1(hours);
            if (hours == 24)
            {
              ++days;
              hours = 0;
              Action<int> days1 = this.Days;
              if (days1 != null)
                days1(days);
            }
          }
        }
      });
      timer.Start();
    }

    public void Dispose()
    {
    }
  }
}
