using System;

public interface IGameplayInputProvider
{
    public bool IsTrueInvoked { get; set; }
    public IObservable<bool> IsTrueInvokedObservable { get; }

    public bool IsFalseInvoked { get; set; }
    public IObservable<bool> IsFalseInvokedObservable { get; }

    public bool IsSkipInvoked { get; set; }
    public IObservable<bool> IsSkipInvokedObservable { get; }
}