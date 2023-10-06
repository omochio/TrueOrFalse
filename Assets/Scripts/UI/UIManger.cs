using UnityEngine;
using UniRx;
using TNRD;
using TrueOrFalse.GameState;

public class UIManager : MonoBehaviour
{
    [SerializeField] 
    SerializableInterface<IGameStateManager> _gameStateManager;
    IGameStateManager GameStateManager => _gameStateManager.Value;

    [SerializeField]
    Canvas _titleCanvas;
    [SerializeField]
    Canvas _ReadyCanvas;
    [SerializeField]
    Canvas _gameplayCanvas;
    [SerializeField]
    Canvas _gameOverCanvas;
    [SerializeField]
    Canvas _pauseCanvas;

    void Start()
    {
        // タイトル
        GameStateManager.CurrentGameStateObservable
            .Where(state => state == GameState.Title)
            .Subscribe(_ => _titleCanvas.gameObject.SetActive(true));
        GameStateManager.CurrentGameStateObservable
            .Where(state => state != GameState.Title)
            .Subscribe(_ => _titleCanvas.gameObject.SetActive(false));

        // ゲーム開始前カウントダウン
        GameStateManager.CurrentGameStateObservable
            .Where(state => state == GameState.Ready)
            .Subscribe(_ => _ReadyCanvas.gameObject.SetActive(true));
        GameStateManager.CurrentGameStateObservable
            .Where(state => state != GameState.Ready)
            .Subscribe(_ => _ReadyCanvas.gameObject.SetActive(false));

        // ゲームプレイ
        GameStateManager.CurrentGameStateObservable
            .Where(state => state == GameState.Gameplay)
            .Subscribe(_ => _gameplayCanvas.gameObject.SetActive(true));
        GameStateManager.CurrentGameStateObservable
            .Where(state => state != GameState.Gameplay)
            .Subscribe(_ => _gameplayCanvas.gameObject.SetActive(false));
            
        // ゲームオーバー
        GameStateManager.CurrentGameStateObservable
            .Where(state => state == GameState.GameOver)
            .Subscribe(_ => _gameOverCanvas.gameObject.SetActive(true));
        GameStateManager.CurrentGameStateObservable
            .Where(state => state != GameState.GameOver)
            .Subscribe(_ => _gameOverCanvas.gameObject.SetActive(false));

        // ポーズ
        GameStateManager.CurrentGameStateObservable
            .Where(state => state == GameState.Pause)
            .Subscribe(_ => _pauseCanvas.gameObject.SetActive(true));
        GameStateManager.CurrentGameStateObservable
            .Where(state => state != GameState.Pause)
            .Subscribe(_ => _pauseCanvas.gameObject.SetActive(false));
    }
}