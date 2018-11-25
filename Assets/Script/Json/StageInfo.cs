using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StageInfo{
    [SerializeField]
    private int stage_id_;
    [SerializeField]
    private string[] usable_bullets_;
    [SerializeField]
    private int[] number_of_bullets_;

    public int StageID
    {
        get
        {
            return stage_id_;
        }
    }

    public string[] UsableBullets
    {
        get
        {
            return usable_bullets_;
        }
    }

    public int[] NumberObBullets
    {
        get
        {
            return number_of_bullets_;
        }
    }
}
