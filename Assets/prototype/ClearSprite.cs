using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSprite : MonoBehaviour
{

    public GameObject clearText;

    public GorlScript gorlScript;

    public GameObject spaceText;

    [SerializeField] private string loadScene;
    [SerializeField] private Color fadeColor = Color.black;
    [SerializeField] private float fadeSpeedMultiplier = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
       
     
    }

    // Update is called once per frame
    void Update()
    {
        if (gorlScript.isClea)
        {
            clearText.SetActive(true);
            spaceText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Initiate.Fade(loadScene, fadeColor, fadeSpeedMultiplier);
            }
        }
    }

   
}
