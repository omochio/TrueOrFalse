using UnityEngine;
using UniRx;
using TNRD;
using omochio.Utility;
using TrueOrFalse.GameState;

class BGMManger : MonoBehaviour
{
    [SerializeField]
    SerializableInterface<IGameStateManager> _gameStateMgr;
    IGameStateManager GameStateMgr => _gameStateMgr.Value;

    [SerializeField]
    AudioClip _titleBGM;
    [SerializeField]
    AudioClip _gameplayBGM;
    [SerializeField]
    AudioClip _gameOverSE;

    AudioSource _audioSrc;

    void Awake()
    {
        this.TryGetComponentDebugError(out _audioSrc);
    }

    public void Start()
    {
        GameStateMgr.CurrentGameStateObservable
            .Subscribe(state =>
            {
                switch (state)
                {
                    case GameState.Title:
                        _audioSrc.clip = _titleBGM;
                        _audioSrc.Play();
                        break;
                    case GameState.Ready:
                        _audioSrc.Stop();
                        break;
                    case GameState.Gameplay:
                        _audioSrc.clip = _gameplayBGM;
                        _audioSrc.Play();
                        break;
                    case GameState.GameOver:
                        _audioSrc.PlayOneShot(_gameOverSE);
                        break;
                }
            });
    }
}