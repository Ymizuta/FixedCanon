using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour {

    /// <summary>
    /// 砲弾オブジェクにアタッチして利用
    /// 爆発弾：着弾した位置から一定範囲のオブジェクトを吹き飛ばす処理を追加する
    /// </summary>

    [SerializeField] private float explosion_force_ = 500.0f;   //周囲のオブジェクトを吹き飛ばす威力(エディターから調整可能)
    [SerializeField] private float explosion_radius_ = 5.0f;    //着弾位置からの半径・範囲内のオブジェクトを吹き飛ばす（エディターから調整可能）
    [SerializeField] private float up_wards_modifire = 3f;      //上方へオブジェクトの浮かせる力（エディターから調整可能）

    /*
    * @ brief   砲弾が接触したオブジェクトがNormalObjectなら周囲一転範囲のオブジェクトを吹き飛ばす
    */
    private void OnCollisionEnter(Collision collision)
    {
        if ((IsStageObject(collision)))
        {
            //着弾位置から一定半径のオブジェクト取得
            Collider[] cols = Physics.OverlapSphere(this.gameObject.transform.position, explosion_radius_);
            //取得したオブジェクト吹き飛ばす
            foreach (Collider target in cols)
            {
                //RigidBodyを持つオブジェクトのみ対象に吹き飛ばす処理を実施
                if (target.GetComponent<Rigidbody>() != null)
                {
                    Rigidbody rigidbody = target.GetComponent<Rigidbody>();
                    rigidbody.AddExplosionForce(explosion_force_, this.gameObject.transform.position, explosion_radius_, up_wards_modifire);
                }
            }
        }
    }

    /*
    * @ brief   砲弾が着弾したオブジェクトがNormalObjetかどうかを判定
    * @ param   collision   着弾・衝突したオブジェクトから渡される
    */
    private bool IsStageObject(Collision collision)
    {
        if (collision.gameObject.tag == StageObjectList.NormalObject)
        {
            return true;
        }
        else
            return false;
    }
}
