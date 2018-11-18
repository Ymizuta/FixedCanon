using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChanger : MonoBehaviour {

    public void ChangeBullet(PlayerParams player_params)
    {
        player_params.SetBullet();
    }
}
