using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDotTest : MonoBehaviour
{
    // 绑定到按钮点击事件上
    public void OnClickMail()
    {
        // 假装“打开了邮件”
        Debug.Log("点击邮件：打开邮件面板");

        // 清除红点状态
        RedPointManager.Instance.SetRedPoint("mail", false);
    }
}
