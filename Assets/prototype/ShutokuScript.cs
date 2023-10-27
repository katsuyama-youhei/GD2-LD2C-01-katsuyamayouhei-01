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
        // SpriteRenderer�R���|�[�l���g���擾
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        // ���͂��擾
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // ���͂���ړ��x�N�g�����쐬
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // �v���C���[�̍��W���X�V
        transform.position += movement * moveSpeed * Time.deltaTime;

        UpdatePlayerDirection(horizontalInput);
    }

    void UpdatePlayerDirection(float horizontalInput)
    {
        // ���������̓��͂����i�E�j�Ȃ�v���C���[���E�����ɁA���i���j�Ȃ獶�����ɂ���
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // �E����
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // ������
        }
        // horizontalInput��0�̏ꍇ�͌�����ύX���Ȃ��i���̂܂܁j
    }
}
