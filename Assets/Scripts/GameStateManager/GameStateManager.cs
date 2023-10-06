using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using Cysharp.Threading.Tasks;

namespace TrueOrFalse.GameState
{
    public enum GameState
    {
        Title,
        Ready,
        Gameplay,
        GameOver,
        Pause
    }

    public class GameStateManager : MonoBehaviour, IGameStateManager
    {
        [SerializeField]
        SceneInformation _sceneInfo;
        public SceneInformation SceneInfo => _sceneInfo;

        ReactiveProperty<GameState> _currentGameStateRP = new();
        public GameState CurrentGameState
        {
            get => _currentGameStateRP.Value;
            set
            {
                _currentGameStateRP.Value = value;
            }
        }
        public IObservable<GameState> CurrentGameStateObservable => _currentGameStateRP;

        public void Awake()
        {
            CurrentGameState = SceneInfo.InitState;
        }

        public void Start()
        {
            _currentGameStateRP.AddTo(this);
            // Temp
            CurrentGameStateObservable
                .Subscribe(state => Debug.Log(state));
        }

        public async void Reload()
        {
            await SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}