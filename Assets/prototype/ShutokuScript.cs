using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutokuScript : MonoBehaviour
{
    private float moveSpeed = 3f;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // SpriteRendererコンポーネントを取得
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        // 入力を取得
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // 入力から移動ベクトルを作成
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // プレイヤーの座標を更新
        transform.position += movement * moveSpeed * Time.deltaTime;

        UpdatePlayerDirection(horizontalInput);
    }

    void UpdatePlayerDirection(float horizontalInput)
    {
        // 水平方向の入力が正（右）ならプレイヤーを右向きに、負（左）なら左向きにする
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // 右向き
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // 左向き
        }
        // horizontalInputが0の場合は向きを変更しない（そのまま）
    }
}
