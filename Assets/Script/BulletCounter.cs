using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCounter : MonoBehaviour {

    //弾切れの場合、trueを返す。
    public bool BulletCount(PlayerParams player_params)
    {
        int i;
        for(i = 0; i < player_params.NumberOfBullets.Length; i++)
        {
            if (player_params.NumberOfBullets[i] != 0)break;
            if (i == player_params.NumberOfBullets.Length - 1)return true;
        }
        return false;
    }
}
