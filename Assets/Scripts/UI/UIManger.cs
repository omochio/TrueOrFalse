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
        // �^�C�g��
        GameStateManager.CurrentGameStateObservable
            .Where(state => state == GameState.Title)
            .Subscribe(_ => _titleCanvas.gameObject.SetActive(true));
        GameStateManager.CurrentGameStateObservable
            .Where(state => state != GameState.Title)
            .Subscribe(_ => _titleCanvas.gameObject.SetActive(false));

        // �Q�[���J�n�O�J�E���g�_�E��
        GameStateManager.CurrentGameStateObservable
            .Where(state => state == GameState.Ready)
            .Subscribe(_ => _ReadyCanvas.gameObject.SetActive(true));
        GameStateManager.CurrentGameStateObservable
            .Where(state => state != GameState.Ready)
            .Subscribe(_ => _ReadyCanvas.gameObject.SetActive(false));

        // �Q�[���v���C
        GameStateManager.CurrentGameStateObservable
            .Where(state => state == GameState.Gameplay)
            .Subscribe(_ => _gameplayCanvas.gameObject.SetActive(true));
        GameStateManager.CurrentGameStateObservable
            .Where(state => state != GameState.Gameplay)
            .Subscribe(_ => _gameplayCanvas.gameObject.SetActive(false));
            
        // �Q�[���I�[�o�[
        GameStateManager.CurrentGameStateObservable
            .Where(state => state == GameState.GameOver)
            .Subscribe(_ => _gameOverCanvas.gameObject.SetActive(true));
        GameStateManager.CurrentGameStateObservable
            .Where(state => state != GameState.GameOver)
            .Subscribe(_ => _gameOverCanvas.gameObject.SetActive(false));

        // �|�[�Y
        GameStateManager.CurrentGameStateObservable
            .Where(state => state == GameState.Pause)
            .Subscribe(_ => _pauseCanvas.gameObject.SetActive(true));
        GameStateManager.CurrentGameStateObservable
            .Where(state => state != GameState.Pause)
            .Subscribe(_ => _pauseCanvas.gameObject.SetActive(false));
    }
}