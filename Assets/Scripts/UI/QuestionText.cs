using UnityEngine;
using TMPro;
using omochio.Utility;

public class QuestionText : MonoBehaviour
{
    TMP_Text _text;
    IQuestionService _questionService;

    void Awake()
    {
        this.TryGetComponentDebugError(out _text);
        _questionService = this.FindObjectOfInterface<IQuestionService>();
        if (_questionService == null) Debug.LogError("QuestionService not found!");
    }

    void Update()
    {
        _text.text = new string('!', _questionService.ExclCount) + _questionService.TextBool.ToString();
    }
}