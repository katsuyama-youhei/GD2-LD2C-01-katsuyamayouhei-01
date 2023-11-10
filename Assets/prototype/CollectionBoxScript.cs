using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionBoxScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    //�@��R�̏����l
    private float defaultDrag = 100.0f;
    //�@���������
    public int count;

    private float lostTimer = 0;

    public GameObject particlePrehub;
    private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        // �I�u�W�F�N�g�̓����蔻����擾
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        // �I�u�W�F�N�g�̒�R�l��ݒ�
        rb2d.drag = defaultDrag;
        count = 0;
        transform=GetComponent<Transform>();
     
    }

    // Update is called once per frame
    void Update()
    {
        if (lostTimer > 0)
        {
            lostTimer -= Time.deltaTime;
        }
        Debug.Log("timer" + lostTimer);
        
    }

    // �v���C���[����n���ꂽ�Ƃ�
    public void SetCount()
    {
        // �擾���𑝉�
        count+=1;
        // ��R�l�����������𑁂߂�
        if (defaultDrag > 0)
        {
            defaultDrag -= 10.0f;
            if (defaultDrag < 0)
            {
                defaultDrag = 0;
            }
            rb2d.drag = defaultDrag;

        }

        for(int i = 0; i < 15; i++)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
            Instantiate(particlePrehub,pos, Quaternion.identity);
        }

        Debug.Log("Drag" + defaultDrag);
    }

    // �擾���𕴎�
    private void LoseCount()
    {
        // �擾����0�ł͂Ȃ��Ƃ�
        if (count > 0)
        {
            if (lostTimer <= 0)
            {
                count-=1;
                //�@�y���Ȃ��R�l�𑝉�
                defaultDrag += 10.0f;
                lostTimer = 2.0f;
            }
           
        }
        rb2d.drag = defaultDrag;
        Debug.Log("Drag" + rb2d.drag);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �G�Ƃ̏Փ˂Ŏ擾���̌���
      
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LoseCount();
        }
    }

}
