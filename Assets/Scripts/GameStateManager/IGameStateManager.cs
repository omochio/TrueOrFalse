using System;
using TrueOrFalse.GameState;

public interface IGameStateManager
{
    public SceneInformation SceneInfo { get; }
    public GameState CurrentGameState { get; set; }
    public IObservable<GameState> CurrentGameStateObservable { get; }
    public void Reload();
}