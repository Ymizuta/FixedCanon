using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMainState : StateBase {

    [SerializeField] PlayerParams player_params_;
    [SerializeField] Shooter shooter_;
    [SerializeField] BulletChanger bullet_changer_;
    [SerializeField] BulletCounter bullet_counter_;
    [SerializeField] Move move_;

    private void Start()
    {
    }

    private void Update()
    {
        //ユーザ操作を受けて(UserOperationクラスで実装)
        if (Input.GetButtonDown("Horizontal"))
        {
            //角度変更
            //move_.Move(direction,speed)
        }
        //ユーザ操作を受けて(UserOperationクラスで実装)
        if (Input.GetMouseButtonDown(0))
        {
            //砲弾発射
            shooter_.Shoot(player_params_.LoadedBullet);
            //弾数減少
            player_params_.ReduceBullet();
            //弾数確認
            bullet_counter_.BulletCount(player_params_);
        }
        //ユーザ操作を受けて(UserOperationクラスで実装)
        if (Input.GetMouseButtonDown(1))
        {
            //砲弾の種類変更
            bullet_changer_.ChangeBullet(player_params_);
        }
    }

    //private void CountBullet()
    //{
    //    //弾数カウント
    //    //各弾数が０でかつ、
    //    //ターゲット数が０でない場合コールバックしてゲームオーバー        
    //}

    private void CountTarget()
    {
        //ターゲット数カウント
        //ターゲット数が０の場合コールバックしてクリア

    }
}
