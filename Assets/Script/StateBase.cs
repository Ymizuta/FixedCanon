using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase : MonoBehaviour {

    public SceneBase scene_;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void Init()
    {
        Debug.Log(this + "が生成された");
    }
}
