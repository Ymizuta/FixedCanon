using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectParams : MonoBehaviour {

    [SerializeField] GameObject stage_object_ = null;
    private GameObject stage_object_clone_ = null;
    private List<GameObject> target_object_;

    public void Init(GameObject stage_object_clone)
    {
        stage_object_clone_ = stage_object_clone;
        target_object_.Clear();
        //子オブジェクトからターゲットオブジェクトのみ取得
        foreach (Transform child in stage_object_clone_.transform)
        {
            if (child.tag == StageObjectList.TargetObject)
            {
                target_object_.Add(child.gameObject);
                //Debug.Log(child.gameObject);
            }
        }
        for (int i = 0; i < target_object_.Count; i++)
        {
            Debug.Log("インデックス番号"+i + "の" +target_object_[i]);
        }
    }

    public GameObject StageObject
    {
        get
        {
            return stage_object_;
        }
    }
    //public GameObject StageObjectClone
    //{
    //    get
    //    {
    //        return stage_object_clone_;
    //    }
    //    set
    //    {
    //        stage_object_clone_ = value;
    //    }
    //}
}
