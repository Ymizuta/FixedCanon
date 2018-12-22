using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove : MonoBehaviour {

    [SerializeField] float speed_;
    private Vector3 point_position_;

    private void Start()
    {
        point_position_ = gameObject.transform.position;
    }

    private void Update()
    {
        gameObject.transform.RotateAround(point_position_,Vector3.up,speed_*Time.deltaTime);
    }

}
