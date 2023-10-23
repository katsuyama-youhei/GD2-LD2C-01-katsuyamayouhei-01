using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionBoxScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    private float defaultDrag = 100.0f;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        // オブジェクトの抵抗値を設定
        rb2d.drag = defaultDrag;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count != 0)
        {
            Debug.Log("CollectionBox" + count);
        }
    }

    public void SetCount()
    {
        count++;
    }
}
