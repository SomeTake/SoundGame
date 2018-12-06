using System.Collections;
using UnityEngine;

public class NotesScript : MonoBehaviour
{

    public int lineNum;
    private GameController _gameController;
    private bool isInLine = false;
    private KeyCode _lineKey;

    void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
        _lineKey = GameUtil.GetKeyCodeByLineNum(lineNum);
    }

    void Update()
    {
        // 消さない！！！
        if (this.transform.position.y > -6.0f)
        {
            this.transform.position += Vector3.down * 10 * Time.deltaTime;
            if (this.transform.position.y < -3.25f)
            {
                Debug.Log("false");
                Destroy(this.gameObject);
            }
        }
        // ここまで！！

        if (isInLine)
        {
            CheckInput(_lineKey);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        isInLine = true;
    }

    void OnTriggerExit(Collider other)
    {
        isInLine = false;
    }

    void CheckInput(KeyCode key)
    {

        if (Input.GetKeyDown(key))
        {
            _gameController.GoodTimingFunc(lineNum);
            Destroy(this.gameObject);
        }
    }
}