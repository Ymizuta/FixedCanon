using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParams : MonoBehaviour
{

    [SerializeField] BulletBase[] bullets_ = null;
    private int[] number_of_bullet_;
    private BulletBase loadedbullet_;
    private int bullet_index_;
    private int default_bullet_index_ = 0;

    private void Start()
    {
        bullet_index_ = default_bullet_index_;

        //弾数初期設定
        number_of_bullet_ = new int[bullets_.Length];
        int i;
        for (i = 0; i < number_of_bullet_.Length; i++)
        {
            number_of_bullet_[i] = 2;
        }
        //初期装備      
        loadedbullet_ = bullets_[bullet_index_];
    }

    public void ReduceBullet()
    {
        if (number_of_bullet_[bullet_index_] > 0)
        { number_of_bullet_[bullet_index_]--; }
    }

    public void SetBullet()
    {
        //配列のインデックスを１つ進める
        bullet_index_++;
        if (bullet_index_ >= bullets_.Length)
        { bullet_index_ = default_bullet_index_; }

        loadedbullet_ = bullets_[bullet_index_];
        Debug.Log("現在の弾は" + loadedbullet_);
    }

    public BulletBase LoadedBullet
    {
        get
        {
            return loadedbullet_;
        }
    }

    public BulletBase[] Bullets
    {
        get
        {
            return bullets_;
        }
    }
    public int[] NumberOfBullets
    {
        get
        {
            return number_of_bullet_;
        }
    }

    public int BulletIndex
    {
        get
        {
            return bullet_index_;
        }
    }

}
