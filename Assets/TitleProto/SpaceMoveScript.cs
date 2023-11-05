using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpaceMoveScript : MonoBehaviour
{
    public float moveDistance = 1.0f; // 上下移動の距離
    public float duration = 2.0f; // アニメーションの時間
    // Start is called before the first frame update
    void Start()
    {
        AnimateSprite();
    }


    void AnimateSprite()
    {
        // スプライトの現在の位置
        Vector3 startPos = transform.position;

        // 上下の目標位置を設定
        Vector3 endPos = startPos + new Vector3(0, moveDistance, 0);

        // 上下のアニメーションを実行
        transform.DOMove(endPos, duration).SetLoops(-1, LoopType.Yoyo);
    }
}
