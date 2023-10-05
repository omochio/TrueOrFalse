using UnityEngine;
using TMPro;
using omochio.Utility;

public class ScoreText : MonoBehaviour
{
    IScoreService _scoreSvc;
    TMP_Text _text;

    void Awake()
    {
        this.TryGetComponentDebugError(out _text);
        _scoreSvc = this.FindObjectOfInterface<IScoreService>();
        if (_scoreSvc == null) Debug.LogError("ScoreService not found!");
    }

    void Update()
    {
        _text.SetText(_scoreSvc.Score.ToString());
    }
}