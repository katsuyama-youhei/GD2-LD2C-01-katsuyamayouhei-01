using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyAdulation : MonoBehaviour
{
    public Transform targetObject;

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
        if (targetObject == null)
        {
            return;
        }
        Vector3 targetPosition = targetObject.position;
        transform.position = targetPosition;
    }
}
