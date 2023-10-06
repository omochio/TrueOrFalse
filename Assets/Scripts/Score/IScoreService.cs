using System;

public interface IScoreService
{
    public int Score { get; set; }
    public IObservable<int> ScoreObservable { get; }
    public int HighScore { get; }
    public IObservable<int> HighScoreObservable { get; }
    public IObservable<bool> IsHighScoreUpdatedObservable { get; }
}