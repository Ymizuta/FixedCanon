using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : BulletBase {

    public NormalBullet()
    {
        damage_ = 5;
    }

    protected override void InstantiateEffect()
    {
        Transform instantiate_transform = this.gameObject.transform;
        GameObject effect = Instantiate(Resources.Load("Effect\\InpactEffect"), instantiate_transform.position, instantiate_transform.rotation) as GameObject;
        Destroy(effect, 2.0f);
    }
}
