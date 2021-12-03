﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    float heightMin = 5.0f;
    float heightMax = 20.0f;
    //前回の2点間の距離
    float pre_point2Dist;
    //初期値
    float cameraHeight = 9.0f;
    Vector3 pre_t1;
    Vector3 pre_t2;

    public Transform target;
    public Vector3 offset;
    private void Start()
    {
        offset = new Vector3(0f, 9f, -3.5f) - target.position;
    }
    void Update()
    {
        /*-------- ピンチイン・ピンチアウト処理 --------*/
        // マルチタッチ判定
        if (Input.touchCount >= 2)
        {
            // タッチしている２点を取得
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);

            //2点タッチ開始時の距離を保持
            if (t2.phase == TouchPhase.Began)
            {
                pre_point2Dist = Vector2.Distance(t1.position, t2.position);
            }
            //タッチ位置の変化を検出
            else if (t1.phase == TouchPhase.Moved || t2.phase == TouchPhase.Moved)
            {
                //2点タッチの位置、各タッチ位置の前回値との差を取得
                float point2Dist = Vector2.Distance(t1.position, t2.position);
                float dist1 = Vector2.Distance(t1.position, pre_t1);
                float dist2 = Vector2.Distance(t2.position, pre_t2);
                //2点間の差が縮んだらマイナス、開いたらプラスにする
                if (Mathf.Sign(point2Dist - pre_point2Dist) >= 0)
                {
                    cameraHeight = (dist1 + dist2) / 100.0f;
                }
                else if (Mathf.Sign(point2Dist - pre_point2Dist) <= 0)
                {
                    cameraHeight = -(dist1 + dist2) / 100.0f;
                }

                //タッチ位置の差に変化があれば変更
                if (cameraHeight != 0)
                {
                    float y = this.transform.position.y;
                    float heightLimitJudg = cameraHeight + y;
                    // 限界値をオーバーした際の処理
                    if (heightLimitJudg > (heightMax + 1.0f))
                    {
                        heightLimitJudg = heightMax;
                    }
                    else if (heightLimitJudg < (heightMin - 1.0f))
                    {
                        heightLimitJudg = heightMin;
                    }
                    else
                    {
                        offset = offset + new Vector3(0, cameraHeight, -0.35f * cameraHeight);
                    }
                }
                //前回値として2点間距離を保持
                pre_point2Dist = point2Dist;
            }
            //前回値としてタッチ位置を保持
            pre_t1 = t1.position;
            pre_t2 = t2.position;
        }
        GetComponent<Transform>().position = target.position + offset;
    }
}
