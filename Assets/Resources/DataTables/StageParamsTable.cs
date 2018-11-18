using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageParams", menuName = "MyGame/Create StageParams")]
public class StageParamsTable : ScriptableObject{

    [SerializeField] int stage_id;
    [SerializeField] BulletBase[] useable_bullet;
    [SerializeField] GameObject[] stage_object;
}
