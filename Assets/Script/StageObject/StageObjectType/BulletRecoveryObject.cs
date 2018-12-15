using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRecoveryObject : StageObject {

    [SerializeField] int recovery_number_of_bullet = 3;
    public System.Action<int> OnHitRecoveryObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject collider_object = collision.gameObject;
            BulletBase bullet_class = collider_object.GetComponent<BulletBase>();
            HitReaction(recovery_number_of_bullet);
        }
    }

    private void HitReaction(int recovery_number)
    {
        if (OnHitRecoveryObject != null)
        {
            OnHitRecoveryObject(recovery_number);
        }
        Destroy(this.gameObject);
    }

    protected override void HitReaction(float damage_){}

}
