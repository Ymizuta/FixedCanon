using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObjectManager : MonoBehaviour {

    private StageObjectParams params_;
    private TargetObjectCounter target_obj_counter;

    public void Setup()
    {
        params_ = this.GetComponent<StageObjectParams>();
        target_obj_counter = this.GetComponent<TargetObjectCounter>();
    }
	
    public StageObjectParams Params
    {
        get
        {
            return params_;
        }
    }

    public TargetObjectCounter TargetObjectCounter
    {
        get
        {
            return target_obj_counter;
        }
    }

    private void OnDestroy()
    {
        params_ = null;
        target_obj_counter = null;
    }
}
