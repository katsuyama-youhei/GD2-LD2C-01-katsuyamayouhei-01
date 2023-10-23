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
        // �I�u�W�F�N�g�̒�R�l��ݒ�
        rb2d.drag = defaultDrag;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCount()
    {
        count++;
        if (defaultDrag > 0)
        {
            defaultDrag -= 10.0f;
            if (defaultDrag < 0)
            {
                defaultDrag = 0;
            }
            rb2d.drag = defaultDrag;

        }
        Debug.Log("Drag" + defaultDrag);
    }
    private void LoseCount()
    {
        if (count > 0)
        {
            count--;
            defaultDrag += 10.0f;
        }
        rb2d.drag = defaultDrag;
        Debug.Log("Drag" + defaultDrag);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �G�Ƃ̏Փ˂Ŏ擾���̌���
        // ���Ńv���C���[��ݒ�
        if (collision.gameObject.CompareTag("Player"))
        {
            LoseCount();
        }
    }

}
