using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCloneMaker : MonoBehaviour {

    [SerializeField] GameObject muzzle_ = null;       //砲弾を生成・発射するオブジェクト

    public BulletBase BulletCloneMake(BulletBase bullet)
    {
        //Debug.Log("砲弾を生成");
        BulletBase bullet_clone = Instantiate(bullet, muzzle_.transform.position, muzzle_.transform.rotation);
        return bullet_clone;
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
