using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {

    private SceneManager instance_;

	// Update is called once per frame
	void Start () {
        //if (Input.GetMouseButtonDown(0))
        //{
            SceneManager.getInstance().NextScene(SceneList.TitleScene, null);
            Destroy(this);
        //}
	}
}
