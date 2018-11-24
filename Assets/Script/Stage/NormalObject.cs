using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalObject : StageObject {

    public System.Action OnHitNormalObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            GameObject collider_object = other.gameObject;
            BulletBase bullet_class = collider_object.GetComponent<BulletBase>();
            HitReaction(bullet_class.Damage);
        }
    }

    protected override void HitReaction(float damage)
    {
        if (OnHitNormalObject != null)
        {
            OnHitNormalObject();
        }
        return;
    }
}
