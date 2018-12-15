﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObjectParams : MonoBehaviour {

    private TargetObjectCounter target_obj_counter;
    [SerializeField] GameObject stage_object_ = null;       //
    private GameObject stage_object_clone_ = null;          //
    private List<TargetObject> target_object_list_;         //
    private List<NormalObject> normal_object_list_;          //
    private List<BulletRecoveryObject> recovery_object_list_;
    public System.Action OnAllTargetDie = null;             //ターゲット全滅時にコールバック
    public System.Action OnNotAllTargetDie = null;          //ターゲット全滅していないときにコールバック
    public System.Action OnRecovery = null;

    public void Init(GameObject stage_object_clone)
    {
        target_obj_counter = this.GetComponent<TargetObjectCounter>();
        stage_object_clone_ = stage_object_clone;
        InitTargetObj();
        InitNormalObj();
        InitRecoveryObj();
    }

    public GameObject StageObjClone
    {
        get
        {
            return stage_object_clone_;
        }
        set
        {
            stage_object_clone_ = value;
        }
    }

    public GameObject StageObject
    {
        get
        {
            return stage_object_;
        }
        set
        {
            stage_object_ = value;
        }
    }

    public List<TargetObject> TargetObjectList
    {
        get
        {
            return target_object_list_;
        }
        set
        {
            target_object_list_ = value;
        }
    }

    public List<NormalObject> NormalObjectList
    {
        set
        {
            normal_object_list_ = value;
        }
    }

    public List<BulletRecoveryObject> RecoveryObjectList
    {
        set
        {
            recovery_object_list_ = value;
        }
    }

    //ターゲットオブジェクトの初期化
    private void InitTargetObj()
    {
        target_object_list_ = new List<TargetObject>();
        //ステージオブジェクトの子オブジェクトの中からターゲットオブジェクトのみ取得
        foreach (Transform child in stage_object_clone_.transform)
        {
            if (child.tag == "Untagged") { Debug.LogWarning("タグのないオブジェクトが存在します：" + child); }
            //TargetObjectのタグが付いているものだけ取得
            if (child.tag == StageObjectList.TargetObject)
            {
                TargetObject target_obj_compenent = child.GetComponent<TargetObject>();
                if (target_obj_compenent == null) { Debug.LogWarning("コンポーネントがアタッチされてません："+ child); }
                target_object_list_.Add(target_obj_compenent);
            }
        }
        //ターゲットオブジェクトにコールバック関数を登録
        for (int i = 0; i < target_object_list_.Count; i++)
        {
            target_object_list_[i].OnTargetObjectDie += OnTargetObjectDieCallBack;
        }
    }

    private void InitNormalObj()
    {
        normal_object_list_ = new List<NormalObject>();
        //ステージオブジェクトの子オブジェクトの中からターゲットオブジェクトのみ取得
        foreach (Transform child in stage_object_clone_.transform)
        {
            NormalObject normal_obj_component;
            if (child.tag == "Untagged") { Debug.LogWarning("タグのないオブジェクトが存在します：" + child); }
            //NormalObjectのタグが付いているものだけ取得
            if (child.tag == StageObjectList.NormalObject)
            {
                normal_obj_component = child.GetComponent<NormalObject>();
                if (normal_obj_component == null) { Debug.LogWarning("コンポーネントがアタッチされていません：" + child); }
                normal_object_list_.Add(normal_obj_component);
                //孫オブジェクトを取得
                foreach(Transform obj in child)
                {
                    if (obj.tag == "Untagged") { Debug.LogWarning("タグのないオブジェクトが存在します：" + child); }
                    normal_obj_component = obj.GetComponent<NormalObject>();
                    if (normal_obj_component == null) { Debug.LogWarning("コンポーネントがアタッチされていません：" + obj); }
                    normal_object_list_.Add(normal_obj_component);
                }
            }
        }
        //ノーマルオブジェクトにコールバック関数を登録
        for (int i = 0; i < normal_object_list_.Count; i++)
        {
            normal_object_list_[i].OnHitNormalObject += OnHitoNormalObjCallBack;
        }
    }

    private void InitRecoveryObj()
    {
        recovery_object_list_ = new List<BulletRecoveryObject>();
        //ステージオブジェクトの子オブジェクトの中からリカバリーオブジェクトのみ取得
        foreach (Transform child in stage_object_clone_.transform)
        {
            if (child.tag == "Untagged") { Debug.LogWarning("タグのないオブジェクトが存在します：" + child); }
            //対象タグが付いているものだけ取得
            if (child.tag == StageObjectList.RecoveryObject)
            {
                BulletRecoveryObject recovery_obj_compenent = child.GetComponent<BulletRecoveryObject>();
                if (recovery_obj_compenent == null) { Debug.LogWarning("コンポーネントがアタッチされてません：" + child); }
                recovery_object_list_.Add(recovery_obj_compenent);
            }
        }
        //対象オブジェクトにコールバック関数を登録
        for (int i = 0; i < recovery_object_list_.Count; i++)
        {
            recovery_object_list_[i].OnHitRecoveryObject += OnHitRecoveryObjCallBack;
        }
    }

    //ターゲットオブジェクトが破壊された際に呼び出し
    private void OnTargetObjectDieCallBack(TargetObject target_obj)
    {
        //コールバックしたTargetObjectをリストから除外
        target_object_list_.Remove(target_obj);
        if (!target_obj_counter.ExistTargetObjects(TargetObjectList))
        {
            //Debug.Log("ターゲットが全滅");
            if (OnAllTargetDie != null)
            {
                //ターゲットが全滅している場合のコールバック
                OnAllTargetDie();
                return;
            }
        }
        else
        //Debug.Log("ターゲットはまだ存在する");
        if (OnNotAllTargetDie != null)
        {
            //ターゲットが生き残っている場合のコールバック
            OnNotAllTargetDie();
        }
    }

    private void OnHitoNormalObjCallBack()
    {
        //Debug.Log("ノーマルオブジェクトにヒット");
        if (OnNotAllTargetDie != null)
        {
            //ターゲットが生き残っている場合のコールバック
            OnNotAllTargetDie();
        }
    }

    private void OnHitRecoveryObjCallBack()
    {
        //Debug.Log("リカバリーオブジェクトにヒット");
        if (OnRecovery != null)
        {
            //砲弾リカバリー処理のコールバック
            OnRecovery();
        }
    }

}
