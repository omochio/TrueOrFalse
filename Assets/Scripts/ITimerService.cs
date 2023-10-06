using System;
using TrueOrFalse.GameState;

public interface ITimerService
{
    public int RemainingTimeSec { get; }
    public IObservable<int> RemainingTimeSecObservable { get; }
}