using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TestInfo{

    [SerializeField]
    public List<Enemy> enemy_;

    public List<Enemy> ToList() { return enemy_; }

}
