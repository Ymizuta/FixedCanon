using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAround : MonoBehaviour {

    [SerializeField] GameObject rotate_center_obj_;
    [SerializeField] float rotate_speed_;

	// Update is called once per frame
	void Update () {
        transform.RotateAround(rotate_center_obj_.transform.position, Vector3.up, rotate_speed_ * Time.deltaTime);
	}
}
