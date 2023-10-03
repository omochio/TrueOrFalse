using System.Threading;
using System.IO;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class ScoreService : MonoBehaviour, IScoreService
{
    int _score;
    public int Score 
    {
        get => _score;
        set
        {
            if (value >= 0) _score = value;
        }
    }

    int _highScore;
    public int HighScore 
    {
        get => _highScore;
        private set
        {
            if (value >= 0) _highScore = value;
        }
    }

    string _filePath;

    void Awake()
    {
        _filePath = Application.persistentDataPath + "/score.json";
    }

    async void Start()
    {
        await LoadScore().SuppressCancellationThrow();
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

    public async UniTask UpdateHighScore()
    {
        if (Score > HighScore)
        {
            HighScore = Score;
            await SaveScore();
        }
    }
}