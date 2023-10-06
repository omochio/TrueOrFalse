using UnityEngine;
using TMPro;
using UniRx;
using TNRD;
using omochio.Utility;

public class TimerText : MonoBehaviour
{
    TMP_Text _text;

    [SerializeField]
    int _textSkipLength;

    [SerializeField]
    SerializableInterface<ITimerService> _timerSvc;
    ITimerService TimerSvc => _timerSvc.Value;

    void Awake()
    {
        this.TryGetComponentDebugError(out _text);
    }

    void Start()
    {
        TimerSvc.RemainingTimeSecObservable
            .Subscribe(time => {
                if (_textSkipLength > 0)
                    _text.SetText($"<sprite name=\"TimerIcon\">{time}");
                else
                    _text.SetText(time.ToString());
                });
    }
}