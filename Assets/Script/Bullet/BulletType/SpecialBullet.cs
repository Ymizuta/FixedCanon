using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet : BulletBase {

    public SpecialBullet()
    {
        damage_ = 3;
    }

    protected override void InstantiateEffect()
    {
        Transform instantiate_transform = this.gameObject.transform;
        GameObject effect = Instantiate(Resources.Load("Effect/ExplosionEffect"), instantiate_transform.position, instantiate_transform.rotation) as GameObject;
        Destroy(effect, 2.0f);
    }
}