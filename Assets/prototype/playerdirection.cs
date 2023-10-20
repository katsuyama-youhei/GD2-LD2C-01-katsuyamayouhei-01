using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdirection : MonoBehaviour
{
    private GameObject player;
    private Vector3 wapu = new Vector3(1f, 0f, 0f);
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

        if(count <= 5)
        {

        }

    }

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
        if (other.CompareTag("BoxCoin"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // Destroy(gameObject);
                //Debug.Log("sefa");
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
        if (player == null)
        {
            return;
        }
        ShutokuScript shutokuScript = player.GetComponent<ShutokuScript>();
        if (shutokuScript == null)
        {
            return;
        }

        Vector3 playerposition = shutokuScript.transform.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Direction(horizontalInput, verticalInput);
        transform.position = playerposition + wapu;
    }


}
