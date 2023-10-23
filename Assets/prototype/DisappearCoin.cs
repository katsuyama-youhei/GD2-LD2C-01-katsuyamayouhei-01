using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearCoin : MonoBehaviour
{
    Rigidbody2D rb;
    public float defaultDrag;
    private void Start()
    {
        rb=gameObject.GetComponent<Rigidbody2D>();
        rb.drag = defaultDrag;
    }

}
