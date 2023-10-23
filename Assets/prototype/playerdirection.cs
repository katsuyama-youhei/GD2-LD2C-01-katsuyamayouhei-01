using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdirection : MonoBehaviour
{
    private GameObject player;
    private GameObject collectionBox;
    private Vector3 wapu = new Vector3(1f, 0f, 0f);
   // 取得上限
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        collectionBox = GameObject.FindGameObjectWithTag("Cage");
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PositionMove();         

    }
    // プレイヤーの向き
    void Direction(float horizontalInput, float verticalInput)
    {
        if (horizontalInput > 0)
        {
            wapu = new Vector3(1f, 0f, 0f);
        }
        else if (horizontalInput < 0)
        {
            wapu = new Vector3(-1f, 0f, 0f);
        }
        else if (verticalInput < 0)
        {
            wapu = new Vector3(0f, -1f, 0f);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BoxCoin"))
        {
            Debug.Log("out");
            // gameObject.SetActive(false);
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("sefa");
                Destroy(other.gameObject);
                
            }
        }
    }*/

    private void OnTriggerStay2D(Collider2D other)
    {
        // コインとぶつかっているときに取得
        if (other.CompareTag("BoxCoin"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // 取得上限以下なら取得
                if (count < 5)
                {
                    count++;
                    Debug.Log("count" + count);
                    Destroy(other.gameObject);
                }
                else
                {
                    Debug.Log("over");
                }

            }
        }

        if (other.CompareTag("Cage"))
        {
            // この条件を変えて取得物のリリースを行う
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (count > 0)
                {
                    count--;
                    Debug.Log("count" + count);
                    CollectionBox2AddCount();
                }
            }
        }
    }

    private void PositionMove()
    {
        //　プレイヤーをとれているかの確認
        if (player == null)
        {
            return;
        }
        
        //　プレイヤーの変数を取得
        ShutokuScript shutokuScript = player.GetComponent<ShutokuScript>();
        
        //　プレイヤーの変数を取得できたかの確認
        if (shutokuScript == null)
        {
            return;
        }
        
        // プレイヤーの位置を取得
        Vector3 playerposition = shutokuScript.transform.position;
        
        // プレイヤーの向きを判定
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Direction(horizontalInput, verticalInput);
        
        //プレイヤーの向いている方向に移動
        transform.position = playerposition + wapu;
    }

    private void CollectionBox2AddCount()
    {
        if (collectionBox == null)
        {
            return;
        }
        CollectionBoxScript collectionBoxScript= collectionBox.GetComponent<CollectionBoxScript>();
        if (collectionBoxScript == null) {
            return;
        }
        collectionBoxScript.SetCount();
    }
}
