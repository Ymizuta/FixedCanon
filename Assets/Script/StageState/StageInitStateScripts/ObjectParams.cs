using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectParams : MonoBehaviour {

    [SerializeField] GameObject stage_object_ = null;
    private GameObject stage_object_clone = null;

    public GameObject StageObject
    {
        get
        {
            return stage_object_;
        }
    }
    public GameObject StageObjectClone
    {
        get
        {
            return stage_object_clone;
        }
        set
        {
            stage_object_clone = value;
        }
    }
}
