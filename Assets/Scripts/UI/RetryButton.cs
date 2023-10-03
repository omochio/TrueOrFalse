using UnityEngine;
using UnityEngine.UI;
using omochio.Utility;

public class RetryButton : MonoBehaviour
{
    Button _button;
    IGameManagementService _gameMgrSvc;

    void Awake()
    {
        this.TryGetComponentDebugError(out _button);
        _gameMgrSvc = this.FindObjectOfInterface<IGameManagementService>();
        if (_gameMgrSvc == null)
            Debug.LogError("GameManagementService is not found.");
        _button.onClick.AddListener(async () => await _gameMgrSvc.Retry());
    }
}