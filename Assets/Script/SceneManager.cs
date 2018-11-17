using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    SceneBase current_scene_;
    [SerializeField] SceneBase stage_scene_ = null;

	// Use this for initialization
	void Start () {
        current_scene_ = Instantiate(stage_scene_);
	}
}
