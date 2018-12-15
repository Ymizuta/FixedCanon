using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRecoveryObject : StageObject {

    public System.Action OnHitRecoveryObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject collider_object = collision.gameObject;
            BulletBase bullet_class = collider_object.GetComponent<BulletBase>();
            HitReaction(bullet_class.Damage);
        }
    }

    protected override void HitReaction(float damage)
    {
        if (OnHitRecoveryObject != null)
        {
            OnHitRecoveryObject();
        }
        Destroy(this.gameObject);
    }
}
