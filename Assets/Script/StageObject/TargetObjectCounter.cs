using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObjectCounter : MonoBehaviour {

    //ゲーム中にターゲットが生き残っているかを判定
    //引数：StageObjectParamsで保有するステージオブジェクトのリスト
    public bool ExistTargetObjects(List<TargetObject> target_object_list)
    {
        for (int i = 0; i < target_object_list.Count; i++)
        {
            if (target_object_list[i] != null)
            {
                //Debug.Log(target_object_list[i] + "が生きています");
                //Debug.Log("ターゲットは全滅していません");
                return true;
            }
        }
        //Debug.Log("ターゲットが全滅");
        return false;
    }
}
