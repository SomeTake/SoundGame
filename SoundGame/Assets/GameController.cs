using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private float[] _timing;
    private int[] _lineNum;

    public string filePass;

    void Start()
    {
        _timing = new float[1024];
        _lineNum = new int[1024];
        LoadCSV();
    }

    void LoadCSV()
    {

        TextAsset csv = Resources.Load(filePass) as TextAsset;
        Debug.Log(csv.text);
        StringReader reader = new StringReader(csv.text);

        int i = 0;
        while (reader.Peek() > -1)
        {

            string line = reader.ReadLine();
            string[] values = line.Split(',');
            for (int j = 0; j < values.Length; j++)
            {
                _timing[i] = float.Parse(values[0]);
                _lineNum[i] = int.Parse(values[1]);
            }
            i++;
        }
    }
}