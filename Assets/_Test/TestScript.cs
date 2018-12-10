using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class TestScript : MonoBehaviour {

    Action SampleDeligate;

    // Use this for initialization
    void Start () {
        //SampleDeligate += AMethod;
        //SampleDeligate += AMethod;
        //SampleDeligate += BMethod;

        SampleDeligate = AMethod;
        SampleDeligate = AMethod;
        SampleDeligate = BMethod;
        SampleDeligate();
    }

    // Update is called once per frame
    void Update () {
    }

    private void AMethod()
    {
        Debug.Log("AMethod");
    }

    private void BMethod()
    {
        Debug.Log("BMthod");
    }

}
