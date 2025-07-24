using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LanguageSwitcher : MonoBehaviour
{
    public void SetLanguageToChinese()
    {
        LocalizationManager.Instance.LoadLanguage(SystemLanguage.Chinese);
    }

    public void SetLanguageToEnglish()
    {
        LocalizationManager.Instance.LoadLanguage(SystemLanguage.English);
    }

    public void SetLanguageToJapanese()
    {
        LocalizationManager.Instance.LoadLanguage(SystemLanguage.Japanese);
    }
}
