using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyScript : MonoBehaviour
{
    public Transform target;
    public bool detection;
    private float movementSpeed = 0.4f;
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
        loopSequence.Join(transform.DORotate(new Vector3(0f, 0f, 180f), 0.1f, RotateMode.FastBeyond360).SetEase(Ease.Linear));
        loopSequence.Append(transform.DOLocalMoveX(-2f, 3f).SetRelative().SetEase(Ease.Linear));
        loopSequence.Join(transform.DORotate(Vector3.zero, 0.1f, RotateMode.FastBeyond360).SetEase(Ease.Linear));
        loopSequence.SetLoops(-1);

    }

    // Update is called once per frame
    void Update()
    {
        float distance2Target = Vector2.Distance(transform.position, target.position);

        if (detection)
        {
            Vector2 direction = (target.position - transform.position).normalized;

            // 方向ベクトルから角度を求める
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // オブジェクトの向きを設定
            transform.rotation = Quaternion.AngleAxis(angle + 180f, Vector3.forward);

            rb.velocity = direction * movementSpeed;
            if (loopSequence.IsPlaying())
            {
                loopSequence.Pause();
            }

        }
        else
        {
            
            rb.velocity = Vector2.zero;
            
                loopSequence.Play();
            
        }

    }

}
