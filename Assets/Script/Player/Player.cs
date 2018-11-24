using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private PlayerParams params_;
    private CanonMove canon_move_;
    private Shooter shooter_;

    //プレイヤークローンのオブジェクト検索用の文字列
    private readonly string mazzle_ = "Mazzle";
    private readonly string canon_base_ = "CanonBase";
    private readonly string barrel_base_ = "BarrelBase";

    public PlayerParams Params
    {
        get
        {
            return params_;
        }
    }

    public CanonMove CanonMove
    {
        get
        {
            return canon_move_;
        }
    }

    public Shooter Shooter
    {
        get
        {
            return shooter_;
        }
    }

    // Use this for initialization
    void Start () {
        //初期化
        params_ = this.GetComponent<PlayerParams>();
        shooter_ = this.GetComponent<Shooter>();
        canon_move_ = this.GetComponent<CanonMove>();
        //プレイヤーオブジェクトの検索・取得
        shooter_.Muzzle = GameObject.Find(mazzle_);
        canon_move_.CanonBase = GameObject.Find(canon_base_);
        canon_move_.BarrelBase = GameObject.Find(barrel_base_);
    }
}
