using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChanger : MonoBehaviour {

    public void ChangeBullet(BulletParams bullet_params)
    {
        bullet_params.SetBullet();
    }
}
