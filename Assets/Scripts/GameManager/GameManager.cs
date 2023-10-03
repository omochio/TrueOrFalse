using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class GameManager : MonoBehaviour, IGameManagementService
{
    [SerializeField, Min(0)]
    int _startCountdownSec;
    public int StartCountdownSec => _startCountdownSec;

    [SerializeField]
    Canvas _beforeGameCanvas;
    [SerializeField]
    Canvas _gamePlayCanvas;
    [SerializeField]
    Canvas _gameOverCanvas;

    [SerializeField]
    GameplayInputHandler _gameplayIpt;

    void Awake()
    {
        InitGame();
    }

    void InitGame()
    {
        _beforeGameCanvas.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        _beforeGameCanvas.gameObject.SetActive(false);
        _gamePlayCanvas.gameObject.SetActive(true);
        _gameplayIpt.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        _gamePlayCanvas.gameObject.SetActive(false);
        _gameplayIpt.gameObject.SetActive(false);
        _gameOverCanvas.gameObject.SetActive(true);
    }

    public async UniTask Retry()
    {
        await SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}