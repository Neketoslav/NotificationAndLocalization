using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class LocalizationWindowView : MonoBehaviour
{
    [SerializeField]
    private Button _buttonRu;
    [SerializeField]
    private Button _buttonEn;


    private void Start()
    {
        _buttonRu.onClick.AddListener(() => ChangeLocale(0));
        _buttonEn.onClick.AddListener(() => ChangeLocale(1));
    }

    private void OnDestroy()
    {
        _buttonRu.onClick.RemoveAllListeners();
        _buttonEn.onClick.RemoveAllListeners();
    }

    private void ChangeLocale(int index)
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}

