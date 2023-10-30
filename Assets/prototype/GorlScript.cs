using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorlScript : MonoBehaviour
{
    public int needNumber;
    public bool isClea;
    private GameObject collectionBox;
    private CollectionBoxScript collectionBoxScript;
    // Start is called before the first frame update
    void Start()
    {
        collectionBox = GameObject.FindGameObjectWithTag("Cage");
        CheakNull();
        isClea = false;
    }

    // Update is called once per frame
    void Update()
    {

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

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cage")){
          if(collectionBoxScript.count>= needNumber)
            {
                isClea = true;
                Debug.Log("clea");
            }
        }
    }
}
