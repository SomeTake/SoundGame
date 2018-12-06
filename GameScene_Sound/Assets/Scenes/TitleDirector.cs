using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // シーン遷移に必要

public class TitleDirector : MonoBehaviour
{
    public bool _TitleFlag = false;
    void Start()
    {
        Invoke("TouchOK",1);
    }
	// Update is called once per frame
	void Update ()
    {
        if (_TitleFlag)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
	}

    void TouchOK()
    {
        _TitleFlag = true;
    }
}
