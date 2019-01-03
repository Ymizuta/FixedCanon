using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    [SerializeField]private float explosion_force_ = 1000.0f;
    [SerializeField]private float explosion_radius_ = 10.0f;
    [SerializeField]private float up_wards_modifire = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            ExplodeObject();
            InstantiateEffect();
        }
    }

    public void ExplodeObject()
    {
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
            Destroy(this.gameObject);
        }
    }

    private void InstantiateEffect()
    {
        Transform instantiate_transform = this.gameObject.transform;
        GameObject effect = Instantiate(Resources.Load("Effect/ExplosionEffect"), instantiate_transform.position, instantiate_transform.rotation) as GameObject;
        Destroy(effect, 2.0f);
    }
}
