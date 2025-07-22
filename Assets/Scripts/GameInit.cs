using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    [Header("游戏设置")] [SerializeField] private int frameRate = 120;
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
        
        InitCanvas();
    }
    
    private void InitCanvas()
    {
        if (!GameObject.Find("MasterCanvas"))
        {
            GameObject canvasPrefab = Resources.Load<GameObject>("Prefabs/UI/MasterCanvas");

            if (canvasPrefab != null)
            {
                GameObject canvas = Instantiate(canvasPrefab);
                canvas.name = "MasterCanvas";

                // 可选：让它不被销毁
                DontDestroyOnLoad(canvas);

                Debug.Log("[MyGameInit] 成功加载 MasterCanvas");
            }
            else
            {
                Debug.LogWarning("[MyGameInit] 未找到 UI 预制体");
            }
        }
    }
}