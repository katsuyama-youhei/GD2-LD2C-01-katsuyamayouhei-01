using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSprite : MonoBehaviour
{
    private GameObject collectionBox;
    private CollectionBoxScript collectionBoxScript;

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
    public GorlScript gorlScript;

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
        if (gorlScript == null)
        {
            return;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
        sprites=GetComponent<SpriteRenderer>();
        collectionBox = GameObject.FindGameObjectWithTag("Cage");
        CheakNull();
    }

    // Update is called once per frame
    void Update()
    {
        if(collectionBoxScript.count == 1)
        {
            sprites.sprite = sprite1;
        }
        else if (collectionBoxScript.count == 2)
        {
            sprites.sprite = sprite2;
        }
        else if (collectionBoxScript.count == 3)
        {
            sprites.sprite = sprite3;
        }
        else if (collectionBoxScript.count == 4)
        {
            sprites.sprite = sprite4;
        }
        else if (collectionBoxScript.count == 5)
        {
            sprites.sprite = sprite5;
        }
        else if (collectionBoxScript.count == 6)
        {
            sprites.sprite = sprite6;
        }
        else if (collectionBoxScript.count == 7)
        {
            sprites.sprite = sprite7;
        }
        else if (collectionBoxScript.count == 8)
        {
            sprites.sprite = sprite8;
        }
        else if (collectionBoxScript.count == 9)
        {
            sprites.sprite = sprite9;
        }
        else if (collectionBoxScript.count == 0)
        {

            sprites.sprite = sprite0;
        }

        if (collectionBoxScript.count >= gorlScript.needNumber)
        {
            sprites.color = Color.yellow;
        }
        else
        {
            sprites.color = Color.white;
        }

    }
}
