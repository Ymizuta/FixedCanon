using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour {

    [SerializeField] private float explosion_force_ = 500.0f;
    [SerializeField] private float explosion_radius_ = 5.0f;
    [SerializeField] private float up_wards_modifire = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        if ((IsStageObject(collision)))
        {
            Collider[] cols = Physics.OverlapSphere(this.gameObject.transform.position, explosion_radius_);
            foreach (Collider target in cols)
            {
                if (target.GetComponent<Rigidbody>() != null)
                {
                    Rigidbody rigidbody = target.GetComponent<Rigidbody>();
                    rigidbody.AddExplosionForce(explosion_force_, this.gameObject.transform.position, explosion_radius_, up_wards_modifire);
                }
            }
        }
    }

    private bool IsStageObject(Collision collision)
    {
        if (collision.gameObject.tag == StageObjectList.NormalObject || collision.gameObject.tag == StageObjectList.NormalObject)
        {
            return true;
        }
        else
            return false;
    }
}
