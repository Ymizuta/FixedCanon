using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    /// <summary>
    /// ・Playerクラスが保持
    /// ・砲弾発射を行うクラス
    /// </summary>

    private GameObject muzzle_ = null;  //砲弾を生成・発射するオブジェクト

    /*
     * @ brief      StageMainStateから呼び出され、引数で渡された砲弾オブジェクトをRigidBody.AddForceで飛ばす処理
     * @ param      bullet_clone    StageMainStateから渡される砲弾オブジェクト
    */
    public void Shoot(BulletBase bullet_clone)
    {
        bullet_clone.GetComponent<Rigidbody>().AddForce(muzzle_.transform.forward * bullet_clone.ShootPower);
        InstantiateEffect();
    }

    /*
     * @ brief      StageInitStateでの初期化時に呼び出される
    */
    public GameObject Muzzle
    {
        get
        {
            return muzzle_;
        }
        set
        {
            muzzle_ = value;
        }
    }

    /*
     * @ brief      Muzzleの位置にエフェクトを生成する
    */
    private void InstantiateEffect()
    {
        GameObject effect = Instantiate(Resources.Load("Effect/ShootEffect"),muzzle_.transform.position,muzzle_.transform.rotation) as GameObject;
        Destroy(effect, 2.0f);
    }

    /*
     * @ brief      参照オブジェクトのメモリ開放
    */
}
