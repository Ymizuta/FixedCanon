using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageDB", menuName = "MyGame/Create StageDB")]
public class StageDataBase : ScriptableObject {

    [SerializeField]
    private List<StageParamsTable> stage_params_table_list = new List<StageParamsTable>();

    //リストを返す
    public List<StageParamsTable> GetStageParamasList()
    {
        return stage_params_table_list;
    }
}
