using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberMoveScript : MonoBehaviour
{

    public GameObject mainCamera;
    public float orijinx=0;
    public float orijiny=0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(mainCamera.transform.position.x+ orijinx, mainCamera.transform.position.y+ orijiny, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(mainCamera.transform.position.x + orijinx, mainCamera.transform.position.y + orijiny, 0f);
    }
}
