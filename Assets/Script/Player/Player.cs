using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private PlayerParams params_;
    private CanonMove canon_move_;
    private Shooter shooter_;

    public int id;

    //プレイヤークローンのオブジェクト検索用の文字列
    private readonly string muzzle_ = "Muzzle";
    private readonly string canon_base_ = "CanonBase";
    private readonly string barrel_base_ = "BarrelBase";

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

    public void SetUp () {
        //初期化
        Debug.Log("プレイヤーセットアップ");
        params_ = this.GetComponent<PlayerParams>();
        shooter_ = this.GetComponent<Shooter>();
        canon_move_ = this.GetComponent<CanonMove>();
        //プレイヤーオブジェクトの検索・取得
        shooter_.Muzzle = GameObject.Find(muzzle_);
        canon_move_.CanonBase = GameObject.Find(canon_base_);
        canon_move_.BarrelBase = GameObject.Find(barrel_base_);
    }
}
