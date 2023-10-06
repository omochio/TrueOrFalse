using UnityEngine;
using TMPro;
using UniRx;
using TNRD;
using omochio.Utility;

public class QuestionText : MonoBehaviour
{
    TMP_Text _text;
    [SerializeField]
    SerializableInterface<IQuestionService> _questionSvc;
    IQuestionService QuestionSvc => _questionSvc.Value;

    void Awake()
    {
        this.TryGetComponentDebugError(out _text);
    }

    void Start()
    {
        QuestionSvc.ExclCountObservable
            .Subscribe(_ => _text.SetText(new string('!', QuestionSvc.ExclCount) + QuestionSvc.TextBool.ToString()));
    }
}