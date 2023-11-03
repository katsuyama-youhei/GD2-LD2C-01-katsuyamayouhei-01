using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInitialize : MonoBehaviour
{
    // Start is called before the first frame update
    // 属性の設定
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Debug.Log("After Scene is loaded and game is running");
        // スクリーンサイズの指定
        Screen.SetResolution(1280, 720, false);
    }
}
