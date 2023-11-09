using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number10Script : MonoBehaviour
{

    private GameObject collectionBox;
    private CollectionBoxScript collectionBoxScript;

    public Sprite sprite0; // �ϐ��̒l��1�̂Ƃ��ɕ\������X�v���C�g
    public Sprite sprite1; // �ϐ��̒l��2�̂Ƃ��ɕ\������X�v���C�g

    private SpriteRenderer sprites;

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

    // Start is called before the first frame update
    void Start()
    {
        sprites = GetComponent<SpriteRenderer>();
        collectionBox = GameObject.FindGameObjectWithTag("Cage");
        CheakNull();
    }

    // Update is called once per frame
    void Update()
    {
        if (collectionBoxScript.count < 10)
        {
            sprites.sprite = sprite0;
            sprites.color = Color.white;
        }
        else if (collectionBoxScript.count >= 10)
        {
            sprites.sprite = sprite1;
            sprites.color = Color.yellow;
        }
    }
}
