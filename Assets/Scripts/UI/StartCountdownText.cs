using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;
using omochio.Utility;

public class StartCountdownText : MonoBehaviour
{
    TMP_Text _text;
    IGameManagementService _gameMgrSvc;

    void Awake()
    {
        this.TryGetComponentDebugError(out _text);
        _gameMgrSvc = this.FindObjectOfInterface<IGameManagementService>();
    }

    async void OnEnable()
    {
        var waitSec = _gameMgrSvc.StartCountdownSec;
        while (waitSec > 0)
        {
            _text.text = waitSec.ToString();
            if (await UniTask.WaitForSeconds(1, cancellationToken: destroyCancellationToken).SuppressCancellationThrow())
                return;
            --waitSec;
        }
        if (await _gameMgrSvc.StartGame(destroyCancellationToken).SuppressCancellationThrow())
            return;
    }
}