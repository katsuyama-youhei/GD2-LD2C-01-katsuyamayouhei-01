using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // gameObject.SetActive(false);
            if (Input.GetKey(KeyCode.Space))
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Destroy(gameObject);
            }
        }
    }
}
