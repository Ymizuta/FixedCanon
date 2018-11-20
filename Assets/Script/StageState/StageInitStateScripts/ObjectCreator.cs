using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour {
    private GameObject stage_object_clone_;

    public void CreateObject(GameObject stage_object)
    {
        stage_object_clone_ = Instantiate(stage_object);
    }

}
