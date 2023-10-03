using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using omochio.Utility;

public class GameManager : MonoBehaviour, IGameManagementService
{
    [SerializeField, Min(0)]
    int _startCountdownSec;
    public int StartCountdownSec => _startCountdownSec;

    [SerializeField, Min(0)]
    int _timeLimitSec;

    public int RemainTimeLimitSec { get; private set; }

    [SerializeField]
    Canvas _beforeGameCanvas;
    [SerializeField]
    Canvas _gameplayCanvas;
    [SerializeField]
    Canvas _gameOverCanvas;

    [SerializeField]
    GameplayInputHandler _gameplayIpt;

    IScoreService _scoreSvc;

    void Awake()
    {
        _scoreSvc = this.FindObjectOfInterface<IScoreService>();
    }

    void Start()
    {
        InitGame();
    }

    void InitGame()
    {
        _gameplayCanvas.gameObject.SetActive(false);
        _gameOverCanvas.gameObject.SetActive(false);
        _gameplayIpt.gameObject.SetActive(false);
        _beforeGameCanvas.gameObject.SetActive(true);
    }

    public async UniTask StartGame(CancellationToken token)
    {
        _beforeGameCanvas.gameObject.SetActive(false);
        _gameOverCanvas.gameObject.SetActive(false);
        _gameplayCanvas.gameObject.SetActive(true);
        _gameplayIpt.gameObject.SetActive(true);
        RemainTimeLimitSec = _timeLimitSec;
        while (RemainTimeLimitSec > 0)
        {
            if (await UniTask.WaitForSeconds(1, cancellationToken: token).SuppressCancellationThrow())
                return;
            --RemainTimeLimitSec;
        }
        await GameOver().SuppressCancellationThrow();
    }

    public async UniTask GameOver()
    {
        if (await _scoreSvc.UpdateHighScore().SuppressCancellationThrow())
            return;
        _beforeGameCanvas.gameObject.SetActive(false);
        _gameplayCanvas.gameObject.SetActive(false);
        _gameplayIpt.gameObject.SetActive(false);
        _gameOverCanvas.gameObject.SetActive(true);
    }

    public async UniTask Retry()
    {
        await SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}