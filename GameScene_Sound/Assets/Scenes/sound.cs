using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
	// Use this for initialization
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // スワイプの長さを求める
        if (Input.GetMouseButtonDown(0))
        {
            // 効果音再生(追加)
            GetComponent<AudioSource>().Play();

        }
    }
}
