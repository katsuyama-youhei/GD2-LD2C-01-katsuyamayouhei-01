using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // �v���C���[�I�u�W�F�N�g���^�O�Ō���
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[��������Ȃ��ꍇ
        if (player == null)
        {
            Debug.LogError("�v���C���[��������܂���B�Q�[�����I�����܂��B");
            // �Q�[�����I������i�G�f�B�^��ł͒�~�j
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
