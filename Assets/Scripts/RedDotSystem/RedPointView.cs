using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPointView : MonoBehaviour
{
   public string redPointKey;
   public GameObject redDotUI;

   private void OnEnable()
   {
      RedPointManager.Instance.OnRedPointChanged += OnRedPointUpdate;
   }

   private void OnDisable()
   {
      RedPointManager.Instance.OnRedPointChanged -= OnRedPointUpdate;
   }

   void OnRedPointUpdate(string key, bool state)
   {
      if (key == redPointKey)
      {
         redDotUI.SetActive(state);
      }
   }

   public void Refresh()
   {
      redDotUI.SetActive(RedPointManager.Instance.GetRedPoint(redPointKey));
   }
}
