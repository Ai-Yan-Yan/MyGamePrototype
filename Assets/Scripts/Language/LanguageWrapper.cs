using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LanguageEntry
{
    public string key;
    public string value;
}

/// <summary>
/// 辅助类用于反序列化 JSON
/// </summary>
public class LanguageWrapper
{
    public List<LanguageEntry> entries;

    public Dictionary<string, string> ToDictionary()
    {
        Dictionary<string, string> dict = new();
        foreach (var entry in entries)
        {
            dict[entry.key] = entry.value;
        }
        return dict;
    }
}
