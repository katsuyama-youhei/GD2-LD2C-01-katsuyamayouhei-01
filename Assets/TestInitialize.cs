using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInitialize : MonoBehaviour
{
    // Start is called before the first frame update
    // �����̐ݒ�
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Debug.Log("After Scene is loaded and game is running");
        // �X�N���[���T�C�Y�̎w��
        Screen.SetResolution(1280, 720, false);
    }
}
