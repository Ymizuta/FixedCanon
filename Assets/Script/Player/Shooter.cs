using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    //[SerializeField] GameObject muzzle_;       //砲弾を生成・発射するオブジェクト（エディターから登録）
    [SerializeField] GameObject muzzle_ = null;       //砲弾を生成・発射するオブジェクト
    public System.Action OnBulletDye;

    public void Shoot(BulletBase bullet_clone)
    {
        Debug.Log(bullet_clone + "を発射");
        //BulletBase bullet_clone = Instantiate(bullet, muzzle_.transform.position, muzzle_.transform.rotation);
        bullet_clone.GetComponent<Rigidbody>().AddForce(muzzle_.transform.forward * bullet_clone.ShootPower);
        Object.Destroy(bullet_clone.gameObject, 2.0f);
        bullet_clone = null;
    }

    //メインステート初期化時に取得
    public GameObject Muzzle
    {
        set
        {
            muzzle_ = value;
        }
    }
}
