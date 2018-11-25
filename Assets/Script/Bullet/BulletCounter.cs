using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCounter : MonoBehaviour {

    //すべての弾種で弾切れの場合、trueを返す。
    public bool ExistBullets(BulletParams bullet_params)
    {
        for (int i = 0; i < bullet_params.NumberOfBullets.Length; i++)
        {
            if (bullet_params.NumberOfBullets[i] != 0)break;
            //滞空中の砲弾がないかを調べる
            GameObject[] array_ = GameObject.FindGameObjectsWithTag("Bullet");
            if (array_.Length > 1)return true;
            if (i == bullet_params.NumberOfBullets.Length - 1)return false;
        }
        return true;
    }
}
