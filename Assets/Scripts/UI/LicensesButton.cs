using UnityEngine;
using UnityEngine.UI;
using TMPro;
using omochio.Utility;

public class LicensesButton : MonoBehaviour
{
    [SerializeField]
    TextAsset _licensesText;

    [SerializeField]
    TMP_Text _writeDist;

    [SerializeField]
    GameObject _licenceUI;

    void Start()
    {
        this.TryGetComponentDebugError(out Button button);

        _writeDist.SetText(_licensesText.text);
        _licenceUI.SetActive(false);

        button.onClick.AddListener(() =>
        {
            _licenceUI.SetActive(true);
        });
    }

}
