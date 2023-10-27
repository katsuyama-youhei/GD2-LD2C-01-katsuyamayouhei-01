using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y >= 0)
        {
            transform.position = new Vector3(0, 0, -10);
            return;
        }
        transform.position = new Vector3(0, player.transform.position.y,-10);
    }
}
