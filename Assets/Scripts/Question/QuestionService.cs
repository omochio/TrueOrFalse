using UnityEngine;
using omochio.Utility;

public class QuestionService : MonoBehaviour, IQuestionService
{
    IGameManagementService _gameMgrSvc;
    IScoreService _scoreSvc;

    [SerializeField]
    Vector2Int _exclRange;

    [SerializeField, Min(0)]
    int _scoreByExcl;

    int _exclCount;
    public int ExclCount 
    {
        get => _exclCount; 
        private set
        {
            if (value >= 0) _exclCount = value;
        }
    }

    public bool TextBool { get; private set; }

    public bool CorrectAnswer => ExclCount % 2 == 0 ? TextBool : !TextBool;

    void Awake()
    {
        _gameMgrSvc = this.FindObjectOfInterface<IGameManagementService>();
        if (_gameMgrSvc == null) Debug.LogError("GameManagementService not found!");
        _scoreSvc = this.FindObjectOfInterface<IScoreService>();
        if (_scoreSvc == null) Debug.LogError("ScoreService not found!");
    }

    public void ResetQuestion()
    {
        TextBool = Random.Range(0, 2) == 1;
        ExclCount = Random.Range(_exclRange.x, _exclRange.y + 1);
    }

    public void Answer(bool answer)
    {
        if (answer == CorrectAnswer)
        {
            // 正解点 + !ボーナス
            _scoreSvc.Score += _scoreByExcl * (ExclCount + 1);
            ResetQuestion();
        }
        else
        {
            _gameMgrSvc.GameOver();
        }
    }

    public void Skip()
    {
        Debug.Log("Skipped!");
        ResetQuestion();
    }

    void OnValidate()
    {
        if (_exclRange.x < 0) _exclRange.x = 0;
        if (_exclRange.y < 0) _exclRange.y = 0;
        if (_exclRange.x > _exclRange.y) _exclRange.x = _exclRange.y;
    }
}
