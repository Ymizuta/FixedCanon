using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StageMainState : StateBase
{
    //StageSceneのメンバ
    //private StageScene stage_scene_;
    //private StageObjectManager stage_obj_manager_;
    //private Player player_;
    //private BulletManager bullet_manager_;    
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
        //stage_scene_ = ((StageScene)scene_);
        //stage_obj_manager_ = ((StageScene)scene_).StageObjectManager;
        //player_ = ((StageScene)scene_).Player;
        //bullet_manager_ = ((StageScene)scene_).BulletManager;

        //発射ボタンのメソッドを登録
        ((StageScene)scene_).FireButton.GetComponent<Button>().onClick.AddListener(this.Shoot);
        ((StageScene)scene_).ChangeButton.GetComponent<Button>().onClick.AddListener(this.ChangeBullet);

        //コールバック登録
        ((StageScene)scene_).StageObjectManager.Params.OnAllTargetDie = OnAllTargetDieCallBack;
        ((StageScene)scene_).StageObjectManager.Params.OnNotAllTargetDie = OnNotAllTargetDieCallBack;
        ((StageScene)scene_).StageObjectManager.Params.OnRecovery = OnRecoveryCallBack;


        //要修正
        GlobalCoroutine.Go(Move());
    }

    /*
     * @ brief  プレイヤーの砲台、砲身の角度を変更する処理
     * @ detail コルーチン処理により毎フレーム呼び出し、ユーザ操作を検知する
     */
    private IEnumerator Move()
    {
        while (true)
        {
            yield return null;

            /*
             *@ brief   GameObjectがnullの場合にオブジェクトを取得する処理 
             *@ detail  ステージ/ステート切り替え時に初期化したGameObjectがnullになるバグを防止
             */
            if (((StageScene)scene_).Player.CanonMove.CanonBase == null)
            { ((StageScene)scene_).Player.CanonMove.CanonBase = GameObject.Find("CanonBase");}
            if (((StageScene)scene_).Player.CanonMove.BarrelBase == null)
            { ((StageScene)scene_).Player.CanonMove.BarrelBase = GameObject.Find("BarrelBase");}

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

        ((StageScene)scene_).Player.CanonMove.HorizontalMove(horizontal_direction_);
        //砲身の仰角調整処理
        vertical_direction_ = -(new_touch_poz_.y - old_touch_poz_.y);
        ((StageScene)scene_).Player.CanonMove.VerticalMove(vertical_direction_);
        //次フレームでの移動のため、old_player_pozに現フレームのnew_player_poz(タッチ位置)を格納
        old_touch_poz_ = new_touch_poz_;
    }

    //砲弾発射（発射ボタンから呼び出し）
    private void Shoot()
    {
        //ゲームオブジェクトの有無をチェック
        if (((StageScene)scene_).Player.Shooter.Muzzle == null) { ((StageScene)scene_).Player.Shooter.Muzzle = GameObject.Find("Muzzle"); }
        if (IsRestOfBullets())
        {
            bullet_clone_ = ((StageScene)scene_).BulletManager.BulletClonMaker.BulletCloneMake(((StageScene)scene_).BulletManager.Params.LoadedBullet);
            ((StageScene)scene_).Player.Shooter.Shoot(bullet_clone_);
            //弾数減少
            ((StageScene)scene_).BulletManager.Params.ReduceBullet();
            //弾数カウント（UIへの反映）
            UpdateNumberOfBulletsUi();
        }
    }

    //砲弾種類変更（砲弾変更ボタンから呼び出し）
    private void ChangeBullet()
    {
        ((StageScene)scene_).BulletManager.BulletChanger.ChangeBullet(((StageScene)scene_).BulletManager.Params);
        //弾数カウント（UIへの反映）
        UpdateNumberOfBulletsUi();
    }

    private void UpdateNumberOfBulletsUi()
    {
        ((StageScene)scene_).NumberOfBulletsText.text
            = "BULLETS:" + ((StageScene)scene_).BulletManager.Params.NumberOfBullets[((StageScene)scene_).BulletManager.Params.BulletIndex].ToString("00");
    }

    //残りの砲弾の有無を判定(発射できるかできないかの判定)
    private bool IsRestOfBullets()
    {
        if (((StageScene)scene_).BulletManager.Params.NumberOfBullets[((StageScene)scene_).BulletManager.Params.BulletIndex] > 0){
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
        scene_.ChangeState(StateList.StageFinishState, null);
        //メンバ変数scene_を解放
        scene_ = null;
    }

    private void OnNotAllTargetDieCallBack()
    {
        //sceneがnullなら処理を中断
        if (!(ExistScene())) return;

        if (!((StageScene)scene_).BulletManager.BulletCounter.ExistBullets(((StageScene)scene_).BulletManager.Params))
        {
            Debug.Log("敵全滅せず・弾切れです！");
            scene_.GetComponent<StageScene>().IsGameOver = true;
            scene_.ChangeState(StateList.StageFinishState, null);
            OnMainStateFinish();
            scene_ = null;
        }
        else
            Debug.Log("続行ッ");
            return;
    }

    private void OnRecoveryCallBack()
    {
        ((StageScene)scene_).BulletManager.Params.AddBullet(0);
        //弾数カウント（UIへの反映）
        UpdateNumberOfBulletsUi();
    }

    private void OnMainStateFinish()
    {
        //scene_ = null;
        //stage_scene_ = null;
        //stage_obj_manager_ = null;
        //player_ = null;
        //bullet_manager_ = null;
        bullet_clone_ = null;
        GameObject coroutine_obj = GameObject.Find("GlobalCoroutine");
        Destroy(coroutine_obj);
        Destroy(((StageScene)scene_).StageUi);
    }

    /*
     * @ brief  scene_がnullでなければtrueを返す 
     * @ detail ターゲット全滅後に滞空中の砲弾がStageObjectに着弾することによるエラーを防止する。
     *          (ターゲット全滅のコールバック後に再度コールバック処理を実施しようとするとStageMainStateのメンバ変数を開放しているためNullReferenceExceptionが発生してしまう)
     *          対処として、ターゲット全滅によるコールバック処理でscene_がnullされていれば処理を中断させる.
     */ 
    private bool ExistScene()
    {
        return scene_ != null;
    }

    ///**
    // * @ brief  現在のステート(CurrentState)がMainStateかを判定
    // * @ detail バグにより、処理が繰り返し実行されることを防止
    //*/
    //private bool IsMainState()
    //{
    //    return (scene_.CurrentState == ((StageScene)scene_).StateDictionary[StateList.StageMainState]);
    //}
}