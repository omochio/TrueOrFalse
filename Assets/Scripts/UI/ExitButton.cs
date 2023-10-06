using UnityEngine;
using UnityEngine.UI;
using omochio.Utility;

public class ExitButton : MonoBehaviour
{
    Button _button;

    void Awake()
    {
        this.TryGetComponentDebugError(out _button);
        _button.onClick.AddListener(() => Application.Quit());
    }
}