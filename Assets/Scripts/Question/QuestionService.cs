using System;
using UnityEngine;
using UniRx;
using TNRD;
using TrueOrFalse.GameState;

using Random = UnityEngine.Random;

public class QuestionService : MonoBehaviour, IQuestionService
{
    [SerializeField]
    SerializableInterface<IGameStateManager> _gameStateMgr;
    IGameStateManager GameStateMgr => _gameStateMgr.Value;

    [SerializeField]
    SerializableInterface<IScoreService> _scoreSvc;
    IScoreService ScoreSvc => _scoreSvc.Value;

    [SerializeField]
    SerializableInterface<IGameplayInputProvider> _gameplayIpt;
    IGameplayInputProvider GameplayIpt => _gameplayIpt.Value;

    [SerializeField]
    Vector2Int _exclRange;

    [SerializeField, Min(0)]
    int _scoreByExcl;

    public bool TextBool { get; private set; }

    public bool CorrectAnswer => ExclCount % 2 == 0 ? TextBool : !TextBool;

    ReactiveProperty<int> _exclCountRP = new();
    public int ExclCount
    {
        get => _exclCountRP.Value;
        private set
        {
            if (value >= 0) _exclCountRP.Value = value;
        }
    }
    public IObservable<int> ExclCountObservable => _exclCountRP;


    void Start()
    {
        _exclCountRP.AddTo(this);

        // 初期化
        ResetQuestion();

        // 入力
        GameplayIpt.IsTrueInvokedObservable
            .Where(x => x)
            .Subscribe(_ => {
                Answer(true);
                GameplayIpt.IsTrueInvoked = false;
            });
        GameplayIpt.IsFalseInvokedObservable
            .Where(x => x)
            .Subscribe(_ => {
                Answer(false);
                GameplayIpt.IsFalseInvoked = false;
            });
        GameplayIpt.IsSkipInvokedObservable
            .Where(x => x)
            .Subscribe(_ => {
                Skip();
                GameplayIpt.IsSkipInvoked = false;
            });
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
            ScoreSvc.Score += _scoreByExcl * (ExclCount + 1);
            ResetQuestion();
        }
        else
            GameStateMgr.CurrentGameState = GameState.GameOver;
    }

    public void Skip()
    {
        ResetQuestion();
    }

    void OnValidate()
    {
        if (_exclRange.x < 0) _exclRange.x = 0;
        if (_exclRange.y < 0) _exclRange.y = 0;
        if (_exclRange.x > _exclRange.y) _exclRange.x = _exclRange.y;
    }
}
