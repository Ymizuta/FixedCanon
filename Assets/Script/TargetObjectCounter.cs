using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObjectCounter : MonoBehaviour {

    public bool ExistTargetObjects(List<GameObject> target_object_list)
    {
        for (int i = 0; i < target_object_list.Count; i++)
        {
            if (target_object_list[i] != null)
            {
                //Debug.Log(target_object_list[i] + "が生きています");
                break;
            }
            if (i == target_object_list.Count -1)
            {
            //Debug.Log("ターゲットは全滅しています");
            return false;
            }
        }
        //Debug.Log("ターゲットは全滅していません");
        return true;
    }
}
