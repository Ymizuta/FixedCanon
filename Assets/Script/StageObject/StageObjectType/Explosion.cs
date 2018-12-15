using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    private float serch_radius_ = 10.0f;
    private float explosion_force_ = 1000.0f;
    private float explosion_radius_ = 10.0f;
    private float up_wards_modifire = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            ExplodeObject();
        }
    }

    public void ExplodeObject()
    {
        {
            Collider[] cols = Physics.OverlapSphere(this.gameObject.transform.position, serch_radius_);
            foreach (Collider target in cols)
            {
                if (target.GetComponent<Rigidbody>() != null)
                {
                    Rigidbody rigidbody = target.GetComponent<Rigidbody>();
                    rigidbody.AddExplosionForce(explosion_force_, this.gameObject.transform.position, explosion_radius_, up_wards_modifire);
                }
            }
            Destroy(this.gameObject);
        }
    }

}
