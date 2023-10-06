using UnityEngine.EventSystems;
using UnityEngine;
using omochio.Utility;

public class PopupCloser : MonoBehaviour
{
    [SerializeField]
    GameObject _popup;

    void Start()
    {
        this.TryGetComponentDebugError(out EventTrigger eventTrigger);

        EventTrigger.Entry entry = new()
        {
            eventID = EventTriggerType.PointerDown
        };

        entry.callback.AddListener(_ =>
        {
            _popup.SetActive(false);
        });

        eventTrigger.triggers.Add(entry);
    }
}