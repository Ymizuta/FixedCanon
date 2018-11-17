using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMainState : StateBase {

    [SerializeField] PlayerParams player_params_;
    [SerializeField] Shooter shooter_;
    [SerializeField] BulletChanger bullet_changer_;
    [SerializeField] BulletCounter bullet_counter_;
    [SerializeField] CanonMove canon_move_;

    private void Start()
    {
    }

    private void Update()
    {
        //砲弾発射
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

        //砲弾変更
        //ユーザ操作を受けて(UserOperationクラスで実装)
        if (Input.GetMouseButtonDown(1))
        {
            //砲弾の種類変更
            bullet_changer_.ChangeBullet(player_params_);
        }

        //角度変更
        //ユーザ操作を受けて(UserOperationクラスで実装)
        TouchInfo info = UserOperation.GetTouch();
        //canon_move_.Move(direction,speed)
        if (info == TouchInfo.Began)
        {
            //CanonMove.Move(vector3 ,speed );
        }
        else if (info == TouchInfo.Moved)
        {
            //CanonMove.Move(vector3 ,speed );
        }
        else if (info == TouchInfo.Ended)
        {
            //処理あれば
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
