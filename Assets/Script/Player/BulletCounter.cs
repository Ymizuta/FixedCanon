using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCounter : MonoBehaviour {

    //すべての弾種で弾切れの場合、trueを返す。
    public bool ExistBullets(PlayerParams player_params)
    {
        for(int i = 0; i < player_params.NumberOfBullets.Length; i++)
        {
            if (player_params.NumberOfBullets[i] != 0)break;
            if (i == player_params.NumberOfBullets.Length - 1)return false;
        }
        return true;
    }
}
