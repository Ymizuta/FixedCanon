using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour {
    protected float damage_;
    protected float shoot_power_ = 1000.0f;

    public void Init()
    {

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
