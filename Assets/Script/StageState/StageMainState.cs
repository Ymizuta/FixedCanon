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
    private readonly string canon_base_ = "CanonBase";
    private readonly string barrel_base_ = "BarrelBase";

    //タッチ操作関連
    private Vector3 touch_poz_;
    private Vector3 old_touch_poz_;
    private Vector3 new_touch_poz_;
    private float horizontal_direction_;

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
        //プレイヤーオブジェクトの検索・取得
        shooter_.Muzzle = GameObject.Find(mazzle_);
        canon_move_.CanonBase = GameObject.Find(canon_base_);
        canon_move_.BarrelBase = GameObject.Find(barrel_base_);
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
        //canon_move_.HorizontalMove(Input.GetAxis("Horizontal"));
        canon_move_.VerticalMove(Input.GetAxis("Vertical"));

        //ユーザ操作を受けて(UserOperationクラスで実装)
        TouchInfo info = UserOperation.GetTouch();
        if (info == TouchInfo.Began)
        {
            touch_poz_ = UserOperation.GetTouchPosition();
            //ScreenToWorldPointメソッドのバグ防止用にｚ座標を設定
            touch_poz_.z = 1.0f;
            old_touch_poz_ = Camera.main.ScreenToWorldPoint(touch_poz_);
            //z座標を初期化
            old_touch_poz_.z = 0f;
        }
        else if (info == TouchInfo.Moved)
        {
            touch_poz_ = UserOperation.GetTouchPosition();
            //ScreenToWorldPointメソッドのバグ防止用にｚ座標を設定
            touch_poz_.z = 1.0f;
            new_touch_poz_ = Camera.main.ScreenToWorldPoint(touch_poz_);
            //z座標を初期化
            new_touch_poz_.z = 0f;
            //砲台の水平回転処理
            horizontal_direction_ = new_touch_poz_.x - old_touch_poz_.x;
            canon_move_.HorizontalMove(horizontal_direction_);
            //砲身の仰角調整処理

            //次フレームでの移動のため、old_player_pozに現フレームのnew_player_poz(タッチ位置)を格納
            old_touch_poz_ = new_touch_poz_;
        }
        else if (info == TouchInfo.Ended)
        {
            //処理あれば
        }
    }

    private void CountTarget()
    {
        //ターゲット数カウント
        //ターゲット数が０の場合コールバックしてクリア
    }
}
