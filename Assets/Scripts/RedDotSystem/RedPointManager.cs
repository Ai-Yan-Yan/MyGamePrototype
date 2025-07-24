using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPointManager : MonoBehaviour
{
   private static RedPointManager _instance;

   public static RedPointManager Instance => _instance ??= new RedPointManager();
   
   private Dictionary<string,bool> redPointStates = new Dictionary<string, bool>();

   public event Action<string, bool> OnRedPointChanged;
   
   //设置红点状态
   public void SetRedPoint(string key, bool show)
   {
      if (redPointStates.ContainsKey(key) && redPointStates[key] == show) return;
      
      redPointStates[key] = show;
      OnRedPointChanged?.Invoke(key, show);
   }
   
   //获取红点状态
   public bool GetRedPoint(string key)
   {
      return redPointStates.TryGetValue(key,out var value) && value;
   }
}
