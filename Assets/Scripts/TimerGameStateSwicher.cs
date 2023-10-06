using UnityEngine;
using UniRx;
using TNRD;
using omochio.Utility;
using TrueOrFalse.GameState;

public class TimerGameStateSwicher : MonoBehaviour
{
    [SerializeField]
    GameState _nextState;

    [SerializeField]
    SerializableInterface<IGameStateManager> _gameStateMgr;
    IGameStateManager GameStateMgr => _gameStateMgr.Value;

    ITimerService _timerSvc;

    void Awake()
    {
        this.TryGetComponentDebugError(out _timerSvc);
    }

    void Start()
    {
        _timerSvc.RemainingTimeSecObservable
            .Where(x => x <= 0)
            .Subscribe(x => GameStateMgr.CurrentGameState = _nextState);
    }
}