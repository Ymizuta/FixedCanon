﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {

    private SceneManager instance_;

	// Update is called once per frame
	void Start () {
        //試験用：リリース時に削除すること
        //PlayerPrefs.DeleteAll();
        //最初のシーン生成をキックする
        SceneManager.getInstance().NextScene(SceneList.TitleScene, null);
        Destroy(this);

        //GlobalCoroutine.Go(MyCoroutine());
    }

    //private IEnumerator MyCoroutine()
    //{
    //    while (true)
    //    {
    //    Debug.Log("Loop");
    //    yield return null;
    //    }
    //}
}