using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{  //移動速度
    private float _speed = 3.0f;

    //x軸方向の入力を保存
    private float _input_x;
    //z軸方向の入力を保存
    private float _input_z;

    void Update()
    {
        //x軸方向、z軸方向の入力を取得
        //Horizontal（水平、横方向）
        _input_x = Input.GetAxis("Horizontal");
        //Vertical（垂直、縦方向）
        _input_z = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(_input_x, 0, _input_z);
        //ベクトルの向きを取得
        Vector3 direction = velocity.normalized;

        //移動距離を計算
        float distance = _speed * Time.deltaTime;
        //移動先を計算
        Vector3 destination = transform.position + direction * distance;

        // キャラクターの位置だけを更新し、向きは変更しない
        transform.position = destination;

    }
}

