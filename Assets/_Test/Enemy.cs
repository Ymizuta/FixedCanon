using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Enemy{

    [SerializeField]
    public string name_;
    [SerializeField]
    public int hp_;
    [SerializeField]
    string[] skills_;

    public Enemy(string name,int hp,string[] skills)
    {
        this.name_ = name;
        this.hp_ = hp;
        this.skills_ = skills;
    }

}
