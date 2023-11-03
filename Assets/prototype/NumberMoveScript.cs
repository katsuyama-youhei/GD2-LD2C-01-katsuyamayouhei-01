using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberMoveScript : MonoBehaviour
{

    public GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(mainCamera.transform.position.x+4.5f, mainCamera.transform.position.y+1.9f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(mainCamera.transform.position.x + 4.5f, mainCamera.transform.position.y + 1.9f, 0f);
    }
}
