using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StageMainState : StateBase
{
    //StageSceneのメンバ
    private StageScene stage_scene_;
    private StageObjectManager stage_obj_manager_;
    private Player player_;
    private BulletManager bullet_manager_;    
    //砲弾クローン
    private BulletBase bullet_clone_;
    //タッチ操作関連
    private Vector3 touch_poz_;
    private Vector3 old_touch_poz_;
    private Vector3 new_touch_poz_;
    private float horizontal_direction_;                    //CanonMoveの水平回転処理の引数
    private float vertical_direction_;                      //CanonMoveの仰角調整処理の引数

    public override void SetUp()
    {
        stage_scene_ = ((StageScene)scene_);
        stage_obj_manager_ = stage_scene_.StageObjectManager;
        player_ = stage_scene_.Player;
        bullet_manager_ = stage_scene_.BulletManager;

        //発射ボタンのメソッドを登録
        stage_scene_.FireButton.GetComponent<Button>().onClick.AddListener(this.Shoot);
        stage_scene_.ChangeButton.GetComponent<Button>().onClick.AddListener(this.ChangeBullet);
        
        //コールバック登録
        stage_obj_manager_.Params.OnAllTargetDie += OnAllTargetDieCallBack;
        stage_obj_manager_.Params.OnNotAllTargetDie += OnNotAllTargetDieCallBack;

        //要修正
        GlobalCoroutine.Go(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            yield return null;

            //ゲームオブジェクトの有無をチェック
            if (player_.CanonMove.CanonBase == null){player_.CanonMove.CanonBase = GameObject.Find("CanonBase");}
            if (player_.CanonMove.BarrelBase == null){player_.CanonMove.BarrelBase = GameObject.Find("BarrelBase");}

            //砲台・砲身の角度調整
            TouchInfo info = UserOperation.GetTouch();
            if (info == TouchInfo.Began)
            {
                TouchBegan();
            }
            else if (info == TouchInfo.Moved)
            {
                TouchMoved();
            }
            else if (info == TouchInfo.Ended)
            {
                //必要な処理があれば追加
            }
        }
    }

    private void TouchBegan()
    {
        touch_poz_ = UserOperation.GetTouchPosition();
        //ScreenToWorldPointメソッドのバグ防止用にｚ座標を設定
        touch_poz_.z = 1.0f;
        old_touch_poz_ = Camera.main.ScreenToWorldPoint(touch_poz_);
        //z座標を初期化
        old_touch_poz_.z = 0f;
    }

    private void TouchMoved()
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

    //砲弾発射（発射ボタンから呼び出し）
    private void Shoot()
    {
        //ゲームオブジェクトの有無をチェック
        if (player_.Shooter.Muzzle == null) { player_.Shooter.Muzzle = GameObject.Find("Muzzle"); }
        if (IsRestOfBullets())
        {
            bullet_clone_ = bullet_manager_.BulletClonMaker.BulletCloneMake(bullet_manager_.Params.LoadedBullet);
            player_.Shooter.Shoot(bullet_clone_);
            //弾数減少
            bullet_manager_.Params.ReduceBullet();
            //弾数カウント（UIへの反映）
            //Debug.Log(player_params_.Bullets[player_params_.BulletIndex] + "の弾数は"
            //+ player_params_.NumberOfBullets[player_params_.BulletIndex] + "発");
        }
    }

    //砲弾種類変更（砲弾変更ボタンから呼び出し）
    private void ChangeBullet()
    {
        bullet_manager_.BulletChanger.ChangeBullet(bullet_manager_.Params);
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
        //scene_以外のメンバ変数のメモリ解放
        OnMainStateFinish();
        scene_.GetComponent<StageScene>().IsGameClear = true;
        scene_.ChangeState(StateList.StageFinishState,null);
        //メンバ変数scene_を解放
        scene_ = null;
        stage_scene_ = null;
    }

    private void OnNotAllTargetDieCallBack()
    {
        //StageMainStateの有無をチェック(FinishStateに遷移していれば処理中断)    
        if (this == null)return;
        else
        if (!bullet_manager_.BulletCounter.ExistBullets(bullet_manager_.Params))
        {
            Debug.Log("敵全滅せず・弾切れです！");
            scene_.GetComponent<StageScene>().IsGameOver = true;
            scene_.ChangeState(StateList.StageFinishState, null);
            OnMainStateFinish();
        }
        else
            Debug.Log("続行ッ");
    }

    private void OnMainStateFinish()
    {
        //scene_ = null;
        //stage_scene_ = null;
        stage_obj_manager_ = null;
        player_ = null;
        bullet_manager_ = null;
        bullet_clone_ = null;
        GameObject coroutine_obj = GameObject.Find("GlobalCoroutine");
        Destroy(coroutine_obj);
        Destroy(stage_scene_.StageUi);
    }
}