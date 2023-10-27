using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    private bool detection;
    private float movementSpeed = 0.2f;
    private Rigidbody2D rb;
    private Sequence loopSequence;

    /*[SerializeField]
    private Vector2 end;
    [SerializeField]
    private float seconds;*/
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        detection = false;
        loopSequence = DOTween.Sequence();

        // transform.DOMove(end, seconds).SetLoops(-1, LoopType.Yoyo);
        loopSequence.Append(transform.DOLocalMoveX(2f, 3f).SetRelative().SetEase(Ease.Linear));
        loopSequence.Append(transform.DOLocalMoveX(-2f, 3f).SetRelative().SetEase(Ease.Linear));
        loopSequence.SetLoops(-1);

    }

    // Update is called once per frame
    void Update()
    {
        float distance2Target = Vector2.Distance(transform.position, target.position);

        if (detection)
        {
            Vector2 direction = (target.position - transform.position).normalized;

            rb.velocity = direction * movementSpeed;
            loopSequence.Pause();

        }
        else
        {
            
            rb.velocity = Vector2.zero;
            loopSequence.Play();
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cage"))
        {
            detection = false;
            Debug.Log("DisHit");
        }
    }

 /*   private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Cage"))
        {
            detection = true;
            Debug.Log("Hit");
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cage"))
        {
            detection = true;
            Debug.Log("Hit");
        }
    }

}
