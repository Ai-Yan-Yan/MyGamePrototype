using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 自动绑定组件
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizeText : MonoBehaviour
{
    public string key;

    private void OnEnable()
    {
        LocalizationManager.OnLanguageChanged += UpdateText;
        UpdateText();
    }

    private void OnDisable()
    {
        LocalizationManager.OnLanguageChanged -= UpdateText;
    }

    private void UpdateText()
    {
        var localized = LocalizationManager.Instance.Get(key);

        if (TryGetComponent<TextMeshProUGUI>(out var tmp))
        {
            tmp.text = localized;
        }else if(TryGetComponent<Text>(out var uiText))
        {
            uiText.text = localized;
        }
    }
}
