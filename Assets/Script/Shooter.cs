using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public void Shoot(BulletBase bullet)
    {
        Debug.Log(bullet + "を発射");
    }

}
