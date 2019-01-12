using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    /// <summary>
    /// ・StageSceneが保持する
    /// ・プレイヤーオブジェクト（砲台）の動作に必要なParams、Shooter、CanonMoveクラスを管理するクラス
    /// </summary>

    private PlayerParams params_;                           //プレイヤーパラメータを管理するクラス
    private CanonMove canon_move_;                          //プレイヤーの砲撃以外の動作を行うクラス
    private Shooter shooter_;                               //プレイヤーの砲撃を行うクラス
    private readonly string muzzle_ = "Muzzle";             //砲身の発射口取得用の文字列
    private readonly string canon_base_ = "CanonBase";      //砲台の土台取得用の文字列
    private readonly string barrel_base_ = "BarrelBase";    //砲身の可動パーツ取得用の文字列

    /*
     * @ brief  プレイヤーのパラメータ管理用クラス
    */
    public PlayerParams Params
    {
        get
        {
            return params_;
        }
        set
        {
            params_ = value;
        }
    }

    /*
     * @ brief  プレイヤー（砲台）の砲撃以外の動作を行うクラス
     * @ detail StageInitStateでの初期化時にアクセスされる
     */
    public CanonMove CanonMove
    {
        get
        {
            return canon_move_;
        }
        set
        {
            canon_move_ = null;
        }
    }

    /*
     * @ brief  プレイヤー（砲台）の砲撃の動作を行うクラス
     * @ detail StageInitStateでの初期化時にアクセスされる
     */
    public Shooter Shooter
    {
        get
        {
            return shooter_;
        }
        set
        {
            shooter_ = value;
        }
    }

    /*
     * @ brief  StageInitStateから実行されるPlayer初期化処理
     */
    public void SetUp () {
        //Playerの動作に必要な処理を行うクラスを取得する
        params_ = this.GetComponent<PlayerParams>();
        shooter_ = this.GetComponent<Shooter>();
        canon_move_ = this.GetComponent<CanonMove>();
        //Shooterクラスによる砲弾発射時に砲弾を生成する起点となるオブジェクトを取得
        shooter_.Muzzle = GameObject.Find(muzzle_);
        //CanonMoveクラスによる水平回転動作をさせるオブジェクトを取得
        canon_move_.CanonBase = GameObject.Find(canon_base_);
        //CanonMoveクラスによる仰角調整動作をさせるオブジェクトを取得（砲身の根本の空オブジェクト）
        canon_move_.BarrelBase = GameObject.Find(barrel_base_);
    }
}