using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class enemyAdulation : MonoBehaviour
{
    public Transform targetObject;
    public EnemyScript enemyScript;
    

    // Start is called before the first frame update
    void Start()
    {
        if (targetObject == null)
        {
            return;
        }
        Vector3 targetPosition = targetObject.position;
        transform.position = targetPosition;


      
    }

    // Update is called once per frame
    void Update()
    {
        /*  if (targetObject == null)
          {
              return;
          }*/
        Vector3 targetPosition = targetObject.position;
        transform.position = targetPosition;

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cage"))
        {
            enemyScript.detection = true;
            Debug.Log("Hit");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cage"))
        {
            enemyScript.detection = false;
            Debug.Log("DisHit");

        }
    }
}