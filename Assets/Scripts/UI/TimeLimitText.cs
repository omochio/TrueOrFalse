using UnityEngine;
using TMPro;
using omochio.Utility;

public class TimeLimitText : MonoBehaviour
{
    TMP_Text _text;
    IGameManagementService _gameMgrSvc;

    void Awake()
    {
        this.TryGetComponentDebugError(out _text);
        _gameMgrSvc = this.FindObjectOfInterface<IGameManagementService>();
        if (_gameMgrSvc == null) 
            Debug.LogError("GameManagementService not found!");
    }

    void Update()
    {
        _text.SetText(_text.text[0..10] + _gameMgrSvc.RemainTimeLimitSec.ToString());
    }
}