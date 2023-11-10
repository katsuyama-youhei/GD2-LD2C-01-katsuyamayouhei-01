using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNumberScript : MonoBehaviour
{

    private GameObject waku;
    private playerdirection playerdirectionScript;

    public Sprite sprite0; // 変数の値が1のときに表示するスプライト
    public Sprite sprite1; // 変数の値が2のときに表示するスプライト
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    public Sprite sprite5;
    public Sprite sprite6;
    public Sprite sprite7;
    public Sprite sprite8;
    public Sprite sprite9;

    private SpriteRenderer sprites;

    public GameObject mainCamera;
    public float orijinx = 0;
    public float orijiny = 0;


    private void CheakNull()
    {
        if (waku == null)
        {
            return;
        }
        playerdirectionScript = waku.GetComponent<playerdirection>();
        if (playerdirectionScript == null)
        {
            return;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        sprites = GetComponent<SpriteRenderer>();
        waku = GameObject.FindGameObjectWithTag("Wakuwaku");
        CheakNull();
        transform.position = new Vector3(mainCamera.transform.position.x + orijinx, mainCamera.transform.position.y + orijiny, -2f);
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = new Vector3(mainCamera.transform.position.x + orijinx, mainCamera.transform.position.y + orijiny, -2f);
        
        if (playerdirectionScript.count == 1)
        {
            sprites.sprite = sprite1;
        }
        else if (playerdirectionScript.count == 2)
        {
            sprites.sprite = sprite2;
        }
        else if (playerdirectionScript.count == 3)
        {
            sprites.sprite = sprite3;
        }
        else if (playerdirectionScript.count == 4)
        {
            sprites.sprite = sprite4;
        }
        else if (playerdirectionScript.count == 5)
        {
            sprites.sprite = sprite5;
        }
        else if (playerdirectionScript.count == 6)
        {
            sprites.sprite = sprite6;
        }
        else if (playerdirectionScript.count == 7)
        {
            sprites.sprite = sprite7;
        }
        else if (playerdirectionScript.count == 8)
        {
            sprites.sprite = sprite8;
        }
        else if (playerdirectionScript.count == 9)
        {
            sprites.sprite = sprite9;
        }
        else if (playerdirectionScript.count == 0)
        {

            sprites.sprite = sprite0;
        }

        if (playerdirectionScript.count == 5)
        {
            sprites.color = Color.red;
        }
        else
        {
            sprites.color = Color.white;
        }
    }
}
