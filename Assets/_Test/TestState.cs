using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestState : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("サーイエッサー！");
        }
	}
}
