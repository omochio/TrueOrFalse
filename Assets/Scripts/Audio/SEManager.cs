using UnityEngine;
using UniRx;
using TNRD;
using omochio.Utility;
using TrueOrFalse.GameState;

class SEManager : MonoBehaviour
{
    [SerializeField]
    SerializableInterface<IGameStateManager> _gameStateMgr;
    IGameStateManager GameStateMgr => _gameStateMgr.Value;

    [SerializeField]
    SerializableInterface<IScoreService> _scoreSvc;
    IScoreService ScoreSvc => _scoreSvc.Value;

    [SerializeField]
    SerializableInterface<IGameplayInputProvider> _iptProvider;
    IGameplayInputProvider IptProvider => _iptProvider.Value;

    [SerializeField]
    AudioClip _gameOverSE;
    [SerializeField]
    AudioClip _correctSE;
    [SerializeField]
    AudioClip _skipSE;

    AudioSource _audioSrc;

    void Awake()
    {
        this.TryGetComponentDebugError(out _audioSrc);
    }

    public void Start()
    {
        GameStateMgr.CurrentGameStateObservable
            .Where(state => state == GameState.GameOver)
            .Subscribe(state =>
            {
                _audioSrc.PlayOneShot(_gameOverSE);
            });
        
        ScoreSvc.ScoreObservable
            .Where(_ => GameStateMgr.CurrentGameState == GameState.Gameplay)
            .Subscribe(_ =>
            {
                _audioSrc.PlayOneShot(_correctSE);
            });

        IptProvider.IsSkipInvokedObservable
            .Where(_ => GameStateMgr.CurrentGameState == GameState.Gameplay)
            .Subscribe(_ =>
            {
                _audioSrc.PlayOneShot(_skipSE);
            });
    }
}