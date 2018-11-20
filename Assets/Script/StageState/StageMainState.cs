﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMainState : StateBase
{

    [SerializeField] GameObject player_ = null;
    [SerializeField] PlayerParams player_params_ = null;
    [SerializeField] Shooter shooter_ = null;
    [SerializeField] BulletChanger bullet_changer_ = null;
    [SerializeField] BulletCounter bullet_counter_ = null;
    [SerializeField] CanonMove canon_move_ = null;
    private GameObject player_clone_;

    //プレイヤークローンのオブジェクト検索用の文字列
    private readonly string mazzle_ = "Mazzle";
    private readonly string canon_base = "CanonBase";
    private readonly string barrel_base = "BarrelBase";

    private void Start()
    {
        //初期設定
        player_clone_ = Instantiate(player_);
        //player_params_ = player_clone_.GetComponent<PlayerParams>();
        //shooter_ = player_clone_.GetComponent<Shooter>();
        //bullet_changer_ = player_clone_.GetComponent<BulletChanger>();
        //bullet_counter_ = player_clone_.GetComponent<BulletCounter>();
        //canon_move_ = player_clone_.GetComponent<CanonMove>();
        player_params_ = this.GetComponent<PlayerParams>();
        shooter_ = this.GetComponent<Shooter>();
        bullet_changer_ = this.GetComponent<BulletChanger>();
        bullet_counter_ = this.GetComponent<BulletCounter>();
        canon_move_ = this.GetComponent<CanonMove>();
        shooter_.Muzzle = GameObject.Find(mazzle_);
        canon_move_.CanonBase = GameObject.Find(canon_base);
        canon_move_.BarrelBase = GameObject.Find(barrel_base);
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
            //弾数カウント（UIへの反映）
            Debug.Log(player_params_.Bullets[player_params_.BulletIndex] + "の弾数は"
                + player_params_.NumberOfBullets[player_params_.BulletIndex] + "発");
            //ゲームオーバー判定（すべての残弾０）
            if (bullet_counter_.BulletCount(player_params_))
            {
                Debug.Log("GameOver");
                //ステート移行
                scene_.ChangeState(StateList.StageFinishState);
            }
        }

        //砲弾変更
        //ユーザ操作を受けて(UserOperationクラスで実装)
        if (Input.GetMouseButtonDown(1))
        {
            //砲弾の種類変更
            bullet_changer_.ChangeBullet(player_params_);
        }

        //角度変更
        //テスト用処理
        canon_move_.HorizontalMove(Input.GetAxis("Horizontal"));
        canon_move_.VerticalMove(Input.GetAxis("Vertical"));

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
