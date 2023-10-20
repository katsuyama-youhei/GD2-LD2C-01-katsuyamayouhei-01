using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーオブジェクトをタグで検索
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーが見つからない場合
        if (player == null)
        {
            Debug.LogError("プレイヤーが見つかりません。ゲームを終了します。");
            // ゲームを終了する（エディタ上では停止）
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
