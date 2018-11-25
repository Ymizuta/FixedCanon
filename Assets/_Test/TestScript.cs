using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    private TestState test_state;
    private TestComponent test_comp;

    // Use this for initialization
    void Start () {
        GameObject test_state_prefab = Resources.Load("TestState") as GameObject;
        //GameObject test_clone = Instantiate(test_state_prefab);
        //test_state = test_clone.GetComponent<TestState>();
        test_state = test_state_prefab.GetComponent<TestState>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("サーイエッサー！");           
            test_comp = ((TestComponent)test_state.gameObject.AddComponent(System.Type.GetType("TestComponent")));
        }
    }
}
