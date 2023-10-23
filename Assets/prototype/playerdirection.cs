using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdirection : MonoBehaviour
{
    private GameObject player;
    private Vector3 wapu = new Vector3(1f, 0f, 0f);
   // �擾���
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PositionMove();

        // ���̏�����ς��Ď擾���̃����[�X���s��
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (count > 0)
            {
                count--;
                Debug.Log("count" + count);
            }
        }


    }
    // �v���C���[�̌���
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
        // �R�C���ƂԂ����Ă���Ƃ��Ɏ擾
        if (other.CompareTag("BoxCoin"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // �擾����ȉ��Ȃ�擾
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
    }

    private void PositionMove()
    {
        //�@�v���C���[���Ƃ�Ă��邩�̊m�F
        if (player == null)
        {
            return;
        }
        
        //�@�v���C���[�̕ϐ����擾
        ShutokuScript shutokuScript = player.GetComponent<ShutokuScript>();
        
        //�@�v���C���[�̕ϐ����擾�ł������̊m�F
        if (shutokuScript == null)
        {
            return;
        }
        
        // �v���C���[�̈ʒu���擾
        Vector3 playerposition = shutokuScript.transform.position;
        
        // �v���C���[�̌����𔻒�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Direction(horizontalInput, verticalInput);
        
        //�v���C���[�̌����Ă�������Ɉړ�
        transform.position = playerposition + wapu;
    }


}
