using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour {
    protected float damage_;
    protected float shoot_power_ = 1000.0f;
    protected float destroy_interval_time_ = 2.0f;
    //public System.Action OnBulletDie;

    public void Init()
    {

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == StageObjectList.NormalObject)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //    if (other.tag == StageObjectList.TargetObject)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == StageObjectList.NormalObject)
        {
            Destroy(this.gameObject);
            //Destroy(this.gameObject, destroy_interval_time_);
        }
        else
        if (collision.gameObject.tag == StageObjectList.TargetObject)
        {
            Destroy(this.gameObject);
        }
        else
        if (collision.gameObject.tag == StageObjectList.RecoveryObject)
        {
            Destroy(this.gameObject);
        }
    }


    //private void OnDestroy()
    //{
    //    if (OnBulletDie != null)
    //    {
    //        OnBulletDie();
    //    }
    //}

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
