using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour {
    private GameObject stage_object_clone_;

    public GameObject CreateObject(GameObject stage_object)
    {
        stage_object_clone_ = Instantiate(stage_object);
        return stage_object_clone_;
    }

}
