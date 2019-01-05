using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    private GameObject muzzle_ = null;       //砲弾を生成・発射するオブジェクト
    public System.Action OnBulletDye;

    public void Shoot(BulletBase bullet_clone)
    {
        //ゲームオブジェクトの有無をチェック
        if (muzzle_ == null) { muzzle_ = GameObject.Find("Muzzle"); }

        Debug.Log(bullet_clone + "を発射");
        //BulletBase bullet_clone = Instantiate(bullet, muzzle_.transform.position, muzzle_.transform.rotation);
        bullet_clone.GetComponent<Rigidbody>().AddForce(muzzle_.transform.forward * bullet_clone.ShootPower);
        //Object.Destroy(bullet_clone.gameObject, 2.0f);
        InstantiateEffect();
    }

    //メインステート初期化時に取得
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

    private void InstantiateEffect()
    {
        GameObject effect = Instantiate(Resources.Load("Effect/ShootEffect"),muzzle_.transform.position,muzzle_.transform.rotation) as GameObject;
        Destroy(effect, 2.0f);
    }

    private void OnDestroy()
    {
        muzzle_ = null;
        OnBulletDye = null;
    }
}
