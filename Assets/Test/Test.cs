using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 30), "测试视频"))
        {
            UIManager.Instance.PushPanel(UIManager.Instance.MediaPanel, "test");
        }
    }
}
