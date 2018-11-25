using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMainState : StateBase
{
    //[SerializeField] TargetObjectCounter target_obj_counter = null;

    private Player player_;
    private StageScene stage_scene_;
    private BulletManager bullet_manager_;

    //プレイヤークローンのオブジェクト検索用の文字列
    private readonly string mazzle_ = "Mazzle";

    //タッチ操作関連
    private Vector3 touch_poz_;
    private Vector3 old_touch_poz_;
    private Vector3 new_touch_poz_;
    private float horizontal_direction_;                    //CanonMoveの水平回転処理の引数
    private float vertical_direction_;                      //CanonMoveの仰角調整処理の引数

    //砲弾クローン
    private BulletBase bullet_clone_;

    private void Start()
    {
        //初期設定
        stage_scene_ = ((StageScene)scene_);
        player_ = stage_scene_.Player;
        bullet_manager_ = stage_scene_.BulletManager;

        //target_obj_counter = this.GetComponent<TargetObjectCounter>();

        //パラムスの設定
        bullet_manager_.Params.InitParams(stage_scene_.StageInfo);

        //プレイヤーオブジェクトの検索・取得
        bullet_manager_.BulletClonMaker.Muzzle = GameObject.Find(mazzle_);
        
        //コールバック登録
        ((StageScene)scene_).ObjParams.OnAllTargetDie += OnAllTargetDieCallBack;
        ((StageScene)scene_).ObjParams.OnNotAllTargetDie += OnNotAllTargetDieCallBack;
    }

    private void Update()
    {
        //砲弾発射
        //ユーザ操作を受けて(UserOperationクラスで実装)
        if (Input.GetMouseButtonDown(0))
        {
            //砲弾発射
            if (IsRestOfBullets()) {
                bullet_clone_ = bullet_manager_.BulletClonMaker.BulletCloneMake(bullet_manager_.Params.LoadedBullet);
                player_.Shooter.Shoot(bullet_clone_);
                //弾数減少
                bullet_manager_.Params.ReduceBullet();
                //弾数カウント（UIへの反映）
                //Debug.Log(player_params_.Bullets[player_params_.BulletIndex] + "の弾数は"
                    //+ player_params_.NumberOfBullets[player_params_.BulletIndex] + "発");
            }
        }

        //砲弾変更
        //ユーザ操作を受けて(UserOperationクラスで実装)
        if (Input.GetMouseButtonDown(1))
        {
            //砲弾の種類変更
            bullet_manager_.BulletChanger.ChangeBullet(bullet_manager_.Params);
        }

        //砲台・砲身の角度調整
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
            player_.CanonMove.HorizontalMove(horizontal_direction_);
            //砲身の仰角調整処理
            vertical_direction_ = -(new_touch_poz_.y - old_touch_poz_.y);
            player_.CanonMove.VerticalMove(vertical_direction_);
            //次フレームでの移動のため、old_player_pozに現フレームのnew_player_poz(タッチ位置)を格納
            old_touch_poz_ = new_touch_poz_;
        }
        else if (info == TouchInfo.Ended)
        {
            //必要な処理があれば追加
        }
    }

    //残りの砲弾の有無を判定(発射できるかできないかの判定)
    private bool IsRestOfBullets()
    {
        if (bullet_manager_.Params.NumberOfBullets[bullet_manager_.Params.BulletIndex] > 0){
            return true;
        }else
        //Debug.Log("弾が切れています");
        return false;
    }
    
    private void OnAllTargetDieCallBack()
    {
        Debug.Log("敵全滅しています！");
        scene_.GetComponent<StageScene>().IsGameClear = true;
        scene_.ChangeState(StateList.StageFinishState,null);
        return;
    }

    private void OnNotAllTargetDieCallBack()
    {
        if (!bullet_manager_.BulletCounter.ExistBullets(bullet_manager_.Params))
        {
            Debug.Log("敵全滅せず・弾切れです！");
            scene_.GetComponent<StageScene>().IsGameOver = true;
            scene_.ChangeState(StateList.StageFinishState, null);
        }
        else
            Debug.Log("続行ッ");
            return;
    }

    private void OnDestroy()
    {
        scene_ = null;
        player_ = null;
        stage_scene_ = null;
        bullet_manager_ = null;
    }

}
