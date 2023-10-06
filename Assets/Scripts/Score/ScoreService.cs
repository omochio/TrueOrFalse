using System;
using System.IO;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;
using TNRD;
using TrueOrFalse.GameState;

public class ScoreService : MonoBehaviour, IScoreService
{
    [SerializeField]
    SerializableInterface<IGameStateManager> _gameStateMgr;
    IGameStateManager GameStateMgr => _gameStateMgr.Value;

    ReactiveProperty<int> _scoreRP { get; } = new();
    public int Score
    {
        get => _scoreRP.Value;
        set 
        { 
            if (value >= 0) 
                _scoreRP.Value = value;
        }
    }
    public IObservable<int> ScoreObservable => _scoreRP;

    ReactiveProperty<int> _highScoreRP { get; } = new();
    public int HighScore
    {
        get => _highScoreRP.Value;
        private set 
        { 
            if (value >= 0) 
                _highScoreRP.Value = value;
        }
    }
    public IObservable<int> HighScoreObservable => _highScoreRP;

    string _filePath;

    void Awake()
    {
        _filePath = Application.persistentDataPath + "/score.json";
    }

    async void Start()
    {
        _scoreRP.AddTo(this).ToUniTask().Forget();
        _highScoreRP.AddTo(this).ToUniTask().Forget();

        GameStateMgr.CurrentGameStateObservable
            .Where(state => state == GameState.GameOver)
            .Where(_ => Score > HighScore)
            .Subscribe(async _ => {
                Debug.Log($"Save");
                HighScore = Score;
                await SaveScore().SuppressCancellationThrow();
                Debug.Log($"Saved");
            });

        await LoadScore().SuppressCancellationThrow();
        Debug.Log($"Load: {HighScore}");
    }

    async UniTask LoadScore()
    {
        if (!File.Exists(_filePath))
        {
            HighScore = 0;
            return;
        }

        using (var reader = new StreamReader(_filePath))
        {
            var json = await reader.ReadToEndAsync();
            var data = JsonUtility.FromJson<ScoreData>(json);
            HighScore = data.HighScore;
        }
    }

    async UniTask SaveScore()
    {
        using (var writer = new StreamWriter(_filePath))
        {
            var data = new ScoreData { HighScore = HighScore };
            var json = JsonUtility.ToJson(data);
            await writer.WriteAsync(json);
        }
        return;
    }
}