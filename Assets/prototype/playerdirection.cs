using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdirection : MonoBehaviour
{
    private GameObject player;
    private GameObject collectionBox;
    private SpriteRenderer spriteRenderer;
    private CollectionBoxScript collectionBoxScript;
    private ShutokuScript shutokuScript;
    private Vector3 wapu = new Vector3(1f, 0f, 0f);
    // �擾���
    public int count;

    private float releseTime;
    private float releseTimer;
    private bool isRelese;

    public GameObject particlePrehub;

    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        collectionBox = GameObject.FindGameObjectWithTag("Cage");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        CheakNull();

        releseTime = 0.5f;
        releseTimer = releseTime;
        isRelese = true;

        audioSource=GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        PositionMove();
        IsReleseTimer();

    }
    // �v���C���[�̌���
    void Direction(float horizontalInput, float verticalInput)
    {
        if (horizontalInput > 0)
        {
            wapu = new Vector3(0.8f, 0f, 0f);
        }
        else if (horizontalInput < 0)
        {
            wapu = new Vector3(-0.8f, 0f, 0f);
        }
        else if (verticalInput < 0)
        {
            wapu = new Vector3(0f, -0.8f, 0f);
        }
        else if (verticalInput > 0)
        {
            wapu = new Vector3(0f, 0.8f, 0f);
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
                    count+=1;
                    Debug.Log("count" + count);
                    audioSource.PlayOneShot(sound1);
                    for (int i = 0; i < 20; i++)
                    {
                        Vector3 pos = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, 0);
                        Instantiate(particlePrehub, pos, Quaternion.identity);
                    }
                    Destroy(other.gameObject);
                }
                else
                {
                    if (!audioSource.isPlaying)
                    {
                        audioSource.PlayOneShot(sound2);
                    }
                    
                    Debug.Log("over");
                }

            }
        }

        if (other.CompareTag("Cage"))
        {
            // ���̏�����ς��Ď擾���̃����[�X���s��
            if (Input.GetKey(KeyCode.Space))
            {
                if (isRelese)
                {
                    if (count > 0)
                    {
                        count -= 1;
                        Debug.Log("count" + count);
                        CollectionBox2AddCount();
                    }
                    isRelese = false;
                }             
               
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cage"))
        {
            spriteRenderer.color = Color.green;
            // ���̏�����ς��Ď擾���̃����[�X���s��
            if (Input.GetKey(KeyCode.Space))
            {
                if (isRelese)
                {
                    if (count > 0)
                    {
                        count -= 1;
                        Debug.Log("count" + count);
                        CollectionBox2AddCount();
                    }
                }
                isRelese = false;
            }
        }
        else if (other.CompareTag("BoxCoin"))
        {
            spriteRenderer.color = Color.blue;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        spriteRenderer.color = Color.white;

    }

    private void PositionMove()
    {


        // �v���C���[�̈ʒu���擾
        Vector3 playerposition = shutokuScript.transform.position;

        // �v���C���[�̌����𔻒�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Direction(horizontalInput, verticalInput);

        //�v���C���[�̌����Ă�������Ɉړ�
        transform.position = playerposition + wapu;
    }

    private void CollectionBox2AddCount()
    {

        collectionBoxScript.SetCount();
    }

    private void CheakNull()
    {
        if (collectionBox == null)
        {
            return;
        }
        collectionBoxScript = collectionBox.GetComponent<CollectionBoxScript>();
        if (collectionBoxScript == null)
        {
            return;
        }

        //�@�v���C���[���Ƃ�Ă��邩�̊m�F
        if (player == null)
        {
            return;
        }

        //�@�v���C���[�̕ϐ����擾
        shutokuScript = player.GetComponent<ShutokuScript>();

        //�@�v���C���[�̕ϐ����擾�ł������̊m�F
        if (shutokuScript == null)
        {
            return;
        }
    }

    private void IsReleseTimer()
    {
        if (!isRelese)
        {
            releseTimer-=1f* Time.deltaTime;
        }
        if (releseTimer <= 0)
        {
            isRelese = true;
            releseTimer = releseTime;
        }
    }

}
