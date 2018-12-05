using UnityEngine;
using System.Collections;
using System.IO;  // <- ここに注意

public class CSVWriter : MonoBehaviour
{

    public string fileName; // 保存するファイル名

    //テスト用
    //  void Start () {
    //      WriteCSV ("Hello,World");
    //  }

    // CSVに書き込む処理
    public void WriteCSV(string txt)
    {
        StreamWriter streamWriter;
        FileInfo fileInfo;
        fileInfo = new FileInfo(Application.dataPath + "/" + fileName + ".csv");
        streamWriter = fileInfo.AppendText();
        streamWriter.WriteLine(txt);
        streamWriter.Flush();
        streamWriter.Close();
    }
}