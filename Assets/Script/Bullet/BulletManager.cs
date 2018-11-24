﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    private BulletParams params_;
    private BulletChanger bullet_changer_;
    private BulletCloneMaker bullet_clone_maker_;
    private BulletCounter bullet_counter_;

    //初期化
    public void SetUp()
    {
        params_ = this.GetComponent<BulletParams>();
        bullet_changer_ = this.GetComponent<BulletChanger>();
        bullet_clone_maker_ = this.GetComponent<BulletCloneMaker>();
        bullet_counter_ = this.GetComponent<BulletCounter>();
    }

    public BulletParams Params
    {
        get
        {
            return params_;
        }
    }

    public BulletChanger BulletChanger
    {
        get
        {
            return bullet_changer_;
        }
    }

    public BulletCloneMaker BulletClonMaker
    {
        get
        {
            return bullet_clone_maker_;
        }
    }

    public BulletCounter BulletCounter
    {
        get
        {
            return bullet_counter_;
        }
    }
}
