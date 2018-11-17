using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] GameObject muzzle_;

    public void Shoot(BulletBase bullet)
    {
        Debug.Log(bullet + "を発射");
        BulletBase bullet_clone = Instantiate(bullet);
        bullet_clone.GetComponent<Rigidbody>().AddForce(muzzle_.transform.forward * bullet.shoot_power_);
        Destroy(bullet_clone,2.0f);
    }

}
