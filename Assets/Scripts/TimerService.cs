using System;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using TNRD;
using TrueOrFalse.GameState;

public class TimerService : MonoBehaviour, ITimerService
{
    [SerializeField]
    GameState _validState;

    [SerializeField, Min(0)]
    int _timeLimitSec;

    ReactiveProperty<int> _remainingTimeSecRP = new();
    public int RemainingTimeSec
    {
        get => _remainingTimeSecRP.Value;
        private set
        {
            if (value >= 0) _remainingTimeSecRP.Value = value;
        }
    }
    public IObservable<int> RemainingTimeSecObservable => _remainingTimeSecRP;

    [SerializeField]
    SerializableInterface<IGameStateManager> _gameStateMgr;
    IGameStateManager GameStateMgr => _gameStateMgr.Value;

    void Awake()
    {
        RemainingTimeSec = _timeLimitSec;
    }

    void Start()
    {
        _remainingTimeSecRP.AddTo(this);

        GameStateMgr.CurrentGameStateObservable
            .Where(state => state == _validState)
            .Subscribe(async _ =>
            {
                while (RemainingTimeSec > 0)
                {
                    await UniTask.Delay(TimeSpan.FromSeconds(1));
                    RemainingTimeSec--;
                }
            });
    }
}