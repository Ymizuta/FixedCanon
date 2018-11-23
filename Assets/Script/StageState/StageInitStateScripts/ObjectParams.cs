using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectParams : MonoBehaviour {

    [SerializeField] GameObject stage_object_ = null;       //
    private GameObject stage_object_clone_ = null;          //
    private List<GameObject> target_object_list_;            //

    public void Init(GameObject stage_object_clone)
    {
        stage_object_clone_ = stage_object_clone;

        target_object_list_ = new List<GameObject>();
        //ステージオブジェクトの子オブジェクトの中からターゲットオブジェクトのみ取得
        foreach (Transform child in stage_object_clone_.transform)
        {
            //TargetObjectのタグが付いているものだけ取得
            if (child.tag == StageObjectList.TargetObject)
            {
                target_object_list_.Add(child.gameObject);
                //Debug.Log(child.gameObject);
            }
        }
        ////ターゲットオブジェクトにコールバック関数を登録
        //for (int i = 0; i < target_object_list_.Count; i++)
        //{
        //    //Debug.Log(i + "番目は"+target_object_list[i]);
        //    target_object_list_[i].GetComponent<TargetObject>().OnTargetObjectDie += OnTargetObjectDieCallBack;
        //}
    }

    public GameObject StageObject
    {
        get
        {
            return stage_object_;
        }
    }

    public List<GameObject> TargetObjectList
    {
        get
        {
            return target_object_list_;
        }
    }

    //ターゲットオブジェクトが破壊された際に呼び出し
    private void OnTargetObjectDieCallBack()
    {
        //for (int i = 0; i < target_object_list.Count; i++)
        //{
        //    if (target_object_list[i] == null)
        //    {
        //        Debug.Log(i + "番目は破壊されています");
        //    }
        //}
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
