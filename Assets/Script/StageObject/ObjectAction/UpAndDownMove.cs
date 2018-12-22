using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownMove : MonoBehaviour {

    private float first_position_y;
    [SerializeField] private float move_speed_y_plus_ = 5f;
    [SerializeField] private float move_speed_y_minus_ = 3f;
    [SerializeField] private float MAX_DISTANCE = 2f;
    [SerializeField] private float MIN_DISTANCE = -2f;
    private bool is_y_plus_move_ = true;

    // Update is called once per frame
    private void Start()
    {
        first_position_y = this.gameObject.transform.position.y;
        is_y_plus_move_ = true;
    }

    void Update()
    {
        if (is_y_plus_move_)
        {
            Vector3 obj_position = this.gameObject.transform.position;
            float obj_position_y = obj_position.y;
            obj_position_y += move_speed_y_plus_ * Time.deltaTime;
            obj_position.y = obj_position_y;
            this.gameObject.transform.position = obj_position;
            if ((IsOverMaxDistance()))
            {
                obj_position = this.gameObject.transform.position;
                obj_position.y = first_position_y + MAX_DISTANCE;
                this.gameObject.transform.position = obj_position;
                is_y_plus_move_ = false;
            }
        }
        else
        if (!is_y_plus_move_)
        {
            Vector3 obj_position = this.gameObject.transform.position;
            float obj_position_y = obj_position.y;
            obj_position_y -= move_speed_y_minus_ * Time.deltaTime;
            obj_position.y = obj_position_y;
            this.gameObject.transform.position = obj_position;
            if ((IsUnderMinDistance()))
            {
                obj_position = this.gameObject.transform.position;
                obj_position.y = first_position_y + MIN_DISTANCE;
                this.gameObject.transform.position = obj_position;
                is_y_plus_move_ = true;
            }
        }
    }

    private bool IsOverMaxDistance()
    {
        return (this.gameObject.transform.position.y > first_position_y + MAX_DISTANCE);
    }

    private bool IsUnderMinDistance()
    {
        return (this.gameObject.transform.position.y < first_position_y + MIN_DISTANCE);
    }

}
