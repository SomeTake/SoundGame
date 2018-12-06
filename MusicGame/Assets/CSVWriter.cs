using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;  // <- ここに注意

public class CSVWriter : MonoBehaviour
{
    public string fileName; // 保存するファイル名

    //テスト用
    //void Start()
    //{
    //    WriteCSV("Hello,World");
    //}

    // CSVに書き込む処理
    public void WriteCSV(string txt)
    {
        StreamWriter streamWriter;  // StreamWriterクラス、ストリームを使って徐々に書き込む
        FileInfo fileInfo;
        fileInfo = new FileInfo(Application.dataPath + "/" + fileName + ".csv");    // 書き込み先の取得
        streamWriter = fileInfo.AppendText();                                       // 
        streamWriter.WriteLine(txt);
        streamWriter.Flush();
        streamWriter.Close();
    }
}
