using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMainState : StateBase
{
    [SerializeField] GameObject player_ = null;
    [SerializeField] PlayerParams player_params_ = null;
    [SerializeField] Shooter shooter_ = null;
    [SerializeField] CanonMove canon_move_ = null;
    [SerializeField] BulletCloneMaker bullet_clone_maker = null;
    [SerializeField] BulletChanger bullet_changer_ = null;
    [SerializeField] BulletCounter bullet_counter_ = null;
    [SerializeField] TargetObjectCounter target_obj_counter = null;
    private GameObject player_clone_;

    //プレイヤークローンのオブジェクト検索用の文字列
    private readonly string mazzle_ = "Mazzle";
    private readonly string canon_base_ = "CanonBase";
    private readonly string barrel_base_ = "BarrelBase";

    //タッチ操作関連
    private Vector3 touch_poz_;
    private Vector3 old_touch_poz_;
    private Vector3 new_touch_poz_;
    private float horizontal_direction_;                    //CanonMoveの水平回転処理の引数
    private float vertical_direction_;                      //CanonMoveの仰角調整処理の引数

    //砲弾クローン
    private BulletBase bullet_clone_;

    //時間差でゲームオーバー/クリアを判定させる
    private const float default_interval_time = 0;
    private float interval_time = 0;
    private float set_interval_time = 0.1f;

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
        canon_move_ = this.GetComponent<CanonMove>();
        bullet_changer_ = this.GetComponent<BulletChanger>();
        bullet_counter_ = this.GetComponent<BulletCounter>();
        bullet_clone_maker = this.GetComponent<BulletCloneMaker>();
        target_obj_counter = this.GetComponent<TargetObjectCounter>();
        //パラムスの設定
        player_params_.InitParams(((StageScene)scene_).StageInfo);
        //プレイヤーオブジェクトの検索・取得
        bullet_clone_maker.Muzzle = GameObject.Find(mazzle_);
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
            if (IsRestOfBullets()) {

                bullet_clone_ = bullet_clone_maker.BulletCloneMake(player_params_.LoadedBullet);
                //bullet_clone_.OnBulletDie += this.OnBulletDieCallBack;
                shooter_.Shoot(bullet_clone_);
                //shooter_.Shoot(player_params_.LoadedBullet);
                //弾数減少
                player_params_.ReduceBullet();
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
            bullet_changer_.ChangeBullet(player_params_);
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
            canon_move_.HorizontalMove(horizontal_direction_);
            //砲身の仰角調整処理
            vertical_direction_ = -(new_touch_poz_.y - old_touch_poz_.y);
            canon_move_.VerticalMove(vertical_direction_);
            //次フレームでの移動のため、old_player_pozに現フレームのnew_player_poz(タッチ位置)を格納
            old_touch_poz_ = new_touch_poz_;
        }
        else if (info == TouchInfo.Ended)
        {
            //必要な処理があれば追加
        }

        ////ゲームオーバー/クリアのチェックを行うまでのインターバルタイム設定
        //if(interval_time > default_interval_time)
        //{
        //    interval_time -= Time.deltaTime;
        //    if (interval_time <= default_interval_time)
        //    {
        //        interval_time = default_interval_time;
        //        GameStatusCheck();
        //    }
        //}
    }

    //残りの砲弾の有無を判定(発射できるかできないかの判定)
    private bool IsRestOfBullets()
    {
        if (player_params_.NumberOfBullets[player_params_.BulletIndex] > 0){
            return true;
        }else
        //Debug.Log("弾が切れています");
        return false;
    }

    //private void OnBulletDieCallBack()
    //{
    //    //Debug.Log("コールバックされました");
    //    bullet_clone_ = null;
    //    interval_time = set_interval_time;
    //}

    //private void GameStatusCheck()
    //{
    //    if (!target_obj_counter.ExistTargetObjects(((StageScene)scene_).ObjParams.TargetObjectList))
    //    {
    //        Debug.Log("ターゲットが全滅");
    //        //ステート移行
    //        scene_.GetComponent<StageScene>().GameClearFlag = true;
    //        scene_.ChangeState(StateList.StageFinishState,null);
    //        return;
    //    }
    //    else
    //    if (!bullet_counter_.ExistBullets(player_params_))
    //    {
    //        Debug.Log("ターゲットは生存・弾切れ");
    //        //ステート移行
    //        scene_.GetComponent<StageScene>().GameOverFlag = true;
    //        scene_.ChangeState(StateList.StageFinishState,null);
    //        return;
    //    }
    //    else
    //    //Debug.Log("ターゲットは生存・残弾あり");
    //    return;
    //}
}
