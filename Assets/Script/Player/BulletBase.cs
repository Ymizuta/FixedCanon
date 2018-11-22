using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour {
    protected float damage_;
    protected float shoot_power_ = 1000.0f;
    public System.Action OnBulletDye;

    public void Init()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == StageObjectList.NormalObject)
        {
            Destroy(this.gameObject);
        }
        if (other.tag == StageObjectList.TargetObject)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (OnBulletDye != null)
        {
            OnBulletDye();
        }
    }

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
