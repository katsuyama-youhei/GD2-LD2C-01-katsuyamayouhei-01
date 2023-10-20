using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wakuwaku"))
        {
            //Debug.Log("out");
            // gameObject.SetActive(false);
            if (Input.GetKey(KeyCode.Space))
            {
             //   Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Wakuwaku"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
               // Destroy(gameObject);
            }
        }
    }
}
