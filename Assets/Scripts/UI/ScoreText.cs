using System.Drawing;
using UnityEngine;
using TMPro;
using TNRD;
using UniRx;
using omochio.Utility;

public class ScoreText : MonoBehaviour
{
    enum ScoreType
    {
        Current,
        High
    }

    [SerializeField]
    ScoreType _scoreType;

    [SerializeField]
    SerializableInterface<IScoreService> _scoreSvc;
    IScoreService ScoreSvc => _scoreSvc.Value;

    TMP_Text _text;

    void Awake()
    {
        this.TryGetComponentDebugError(out _text);
    }

    void Start()
    {
        switch (_scoreType)
        {
            case ScoreType.Current:
                ScoreSvc.ScoreObservable
                    .Subscribe(_ => _text.SetText(ScoreSvc.Score.ToString()));
                break;
            case ScoreType.High:
                ScoreSvc.HighScoreObservable
                    .Subscribe(_ => _text.SetText($"<sprite name=\"CrownIcon\">{ScoreSvc.HighScore}"));
                ScoreSvc.IsHighScoreUpdatedObservable
                    .Where(x => x)
                    .Subscribe(_ =>
                    {
                        _text.SetText($"<color=#DCDCAA>NEW RECORD</color>");
                    });
                break;
        }
    }
}