using System.Collections;
using System.Collections.Generic;
using System.IO;
using QFramework;
using UnityEngine;

/// <summary>
/// 多语言管理器
/// </summary>
public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance { get; private set; }

    private Dictionary<string, string> _languageTable = new();
    public SystemLanguage CurrentLanguage { get; private set; } = SystemLanguage.English;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadLanguage(CurrentLanguage);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLanguage(SystemLanguage language)
    {
        CurrentLanguage = language;

        string langCode = language switch
        {
            SystemLanguage.Chinese => "zh",
            SystemLanguage.English => "en",
            _ => "en"
        };
        
        string filePath = Path.Combine(Application.streamingAssetsPath, $"Languages/language_{langCode}.json");
        
        Debug.Log(filePath);
        if (!File.Exists(filePath))
        {
            Debug.LogError("语言文件未找到");
            return;
        }
        
        string json = File.ReadAllText(filePath);
        
        // 解析 JSON 到 Dictionary
        _languageTable = JsonUtility.FromJson<LanguageWrapper>(json).ToDictionary();
        
        //广播语言变化
        OnLanguageChanged?.Invoke();
    }

    public string Get(string key)
    {
        return _languageTable.TryGetValue(key, out string value) ? value : $"#{key}";
    }
    
    public static event System.Action OnLanguageChanged;
}
