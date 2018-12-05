using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppUtil : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public static class AppUtil
{
    private static Vector3 TouchPosition = Vector3.zero;

    /// <summary>
    /// タッチ情報を取得(エディタと実機を考慮)
    /// </summary>
    /// <returns>タッチ情報。タッチされていない場合は null</returns>
    public static TouchInfo GetTouch()
    {
        if (AppConst.IsEditor)
        {
            if (Input.GetMouseButtonDown(0)) { return TouchInfo.Began; }
            if (Input.GetMouseButton(0)) { return TouchInfo.Moved; }
            if (Input.GetMouseButtonUp(0)) { return TouchInfo.Ended; }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                return (TouchInfo)((int)Input.GetTouch(0).phase);
            }
        }
        return TouchInfo.None;
    }

    /// <summary>
    /// タッチポジションを取得(エディタと実機を考慮)
    /// </summary>
    /// <returns>タッチポジション。タッチされていない場合は (0, 0, 0)</returns>
    public static Vector3 GetTouchPosition()
    {
        if (AppConst.IsEditor)
        {
            TouchInfo touch = AppUtil.GetTouch();
            if (touch != TouchInfo.None) { return Input.mousePosition; }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                TouchPosition.x = touch.position.x;
                TouchPosition.y = touch.position.y;
                return TouchPosition;
            }
        }
        return Vector3.zero;
    }

    /// <summary>
    /// タッチワールドポジションを取得(エディタと実機を考慮)
    /// </summary>
    /// <param name='camera'>カメラ</param>
    /// <returns>タッチワールドポジション。タッチされていない場合は (0, 0, 0)</returns>
    public static Vector3 GetTouchWorldPosition(Camera camera)
    {
        return camera.ScreenToWorldPoint(GetTouchPosition());
    }
}

/// <summary>
/// タッチ情報。UnityEngine.TouchPhase に None の情報を追加拡張。
/// </summary>
public enum TouchInfo
{
    /// <summary>
    /// タッチなし
    /// </summary>
    None = 99,

    // 以下は UnityEngine.TouchPhase の値に対応
    /// <summary>
    /// タッチ開始
    /// </summary>
    Began = 0,
    /// <summary>
    /// タッチ移動
    /// </summary>
    Moved = 1,
    /// <summary>
    /// タッチ静止
    /// </summary>
    Stationary = 2,
    /// <summary>
    /// タッチ終了
    /// </summary>
    Ended = 3,
    /// <summary>
    /// タッチキャンセル
    /// </summary>
    Canceled = 4,
}