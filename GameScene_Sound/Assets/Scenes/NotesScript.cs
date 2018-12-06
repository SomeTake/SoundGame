using UnityEngine;
using System.Collections;

public class NotesScript : MonoBehaviour
{

    void Update()
    {
        this.transform.position += Vector3.down * 10 * Time.deltaTime;
        if (this.transform.position.y < -5.0f)
        {
            Debug.Log("false");
            Destroy(this.gameObject);
        }
    }
}