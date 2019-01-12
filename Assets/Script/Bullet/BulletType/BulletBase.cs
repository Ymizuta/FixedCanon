using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour {

    /// <summary>
    /// 砲弾の着弾時の挙動、RididBodyで飛ばされる勢い等を設定する抽象クラス
    /// サブクラスを砲弾オブジェクトにアタッチして利用する
    /// </summary>

    protected float damage_;                        //砲弾のダメージを設定
    protected float shoot_power_ = 1000.0f;         //RigidBody.Addで加えられる力
    protected float destroy_interval_time_ = 2.0f;  //着弾後にDestroyされるまでのインターバル時間

    //サブクラスにて初期化する固有の処理があれば実装
    public void Init(){}

    /*
    * @ brief      着弾時の挙動。着弾した際の挙動は、各種砲弾で統一する。
    */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == StageObjectList.NormalObject)
        {
            Destroy(this.gameObject);
            InstantiateEffect();
        }
        else
        if (collision.gameObject.tag == StageObjectList.TargetObject)
        {
            Destroy(this.gameObject);
            InstantiateEffect();
        }
        else
        if (collision.gameObject.tag == StageObjectList.RecoveryObject)
        {
            Destroy(this.gameObject);
        }
    }

    /*
    * @ brief      着弾時のエフェクト生成。サブクラスの砲弾で固有のエフェクトを実装させる。
    */
    protected abstract void InstantiateEffect();

    /*
    * @ brief      （現時点では未実装）オブジェクトにライフ等を設定する場合に砲弾のダメージを取得させる
    */
    public float Damage
    {
        get
        {
            return damage_;       
        }
        set
        {
            damage_ = value;
        }
    }

    /*
    * @ brief      StageMainStateが取得し、Shooterクラスに渡すことで砲弾を飛ばす処理に利用される
    * @ detail     ShooterクラスShootメソッド内のRigidBody.Addメソッド処理にて利用
    */
    public float ShootPower
    {
        get
        {
            return shoot_power_;
        }
        set
        {
            shoot_power_ = value;
        }
    }
}
