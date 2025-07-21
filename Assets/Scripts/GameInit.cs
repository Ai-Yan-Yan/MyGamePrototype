using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    [Header("游戏设置")] [SerializeField] private int frameRate = 60;
    [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private bool runInBackground = true;
    [SerializeField] private bool neverSleep = true;

    void Start()
    {
        Application.targetFrameRate = frameRate;
        Time.timeScale = gameSpeed;
        Application.runInBackground = runInBackground;
        Screen.sleepTimeout = neverSleep ? SleepTimeout.NeverSleep : SleepTimeout.SystemSetting;

        Debug.Log(
            $"[MyGameInit] FrameRate: {frameRate}, GameSpeed: {gameSpeed}, RunInBackground: {runInBackground}, NeverSleep: {neverSleep}");
    }
}