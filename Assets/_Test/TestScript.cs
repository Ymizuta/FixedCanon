using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    private TestState test_state;

	// Use this for initialization
	void Start () {
        GameObject test_state_prefab = Resources.Load("TestState") as GameObject;
        GameObject test_clone = Instantiate(test_state_prefab);
        test_state = test_clone.GetComponent<TestState>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
