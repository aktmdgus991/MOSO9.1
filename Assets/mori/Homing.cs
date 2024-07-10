using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    Transform playerTr; // プレイヤーのTransform
    [SerializeField] float speed = 2; // 敵の動くスピード

    private void Start()
    {
        // プレイヤーのTransformを取得（プレイヤーのタグをPlayerに設定必要）
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {

        // プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
        if (Vector3.Distance(transform.position, playerTr.position) < 1.5f)
            return;

        // プレイヤーに向けて進む
        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(playerTr.position.x, 1,playerTr.position.z),
            speed * Time.deltaTime);
    }
}
