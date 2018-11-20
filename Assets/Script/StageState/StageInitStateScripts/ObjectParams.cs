using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectParams : MonoBehaviour {

    [SerializeField] GameObject stage_object_ = null;

    public GameObject StageObject
    {
        get
        {
            return stage_object_;
        }
    }
}
