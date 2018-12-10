using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCounter : MonoBehaviour {

    //すべての弾種で弾切れの場合、falseを返す。
    public bool ExistBullets(BulletParams bullet_params)
    {
        for (int i = 0; i < bullet_params.NumberOfBullets.Length; i++)
        {
            if (ExistInBulletsList(bullet_params,i))break;
            if (!(ExistBulletInGameView()) && (IsNumberOfBulletsListFinish(bullet_params, i)))return false;
        }
        return true;
    }

    /*
     * @brief   Bulletsの弾数を管理するリストに格納される値(弾数)が0でなければtrueを返す
     */
    private bool ExistInBulletsList(BulletParams bullet_params,int i)
    {
        return (bullet_params.NumberOfBullets[i] != 0);
    }

    /*
     * @brief   Bulletsの弾数を管理するリストのインデックスが末尾まで進むとtrueを返す
    */
    private bool IsNumberOfBulletsListFinish(BulletParams bullet_params, int i)
    {
        return (i == bullet_params.NumberOfBullets.Length - 1);
    }

    ///*
    // * @ brief  GameViewに存在する（滞空中の）Bulletがあればtrueを返す
    // */
    private bool ExistBulletInGameView()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("Bullet");
        if (array.Length > 1) return true;
        else return false;
    }
}
