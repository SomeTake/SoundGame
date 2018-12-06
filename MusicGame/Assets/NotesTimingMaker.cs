using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesTimingMaker : MonoBehaviour
{

    private AudioSource _audioSource;
    private float _startTime = 0;
    private CSVWriter _CSVWriter;

    private bool _isPlaying = false;
    public GameObject startButton;

    // １回だけ発生
    void Start()
    {
        // GameMusicオブジェクトを探す
        _audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        // CSVWriterオブジェクトを探す
        _CSVWriter = GameObject.Find("CSVWriter").GetComponent<CSVWriter>();
    }

    // 毎フレーム発生
    void Update()
    {
        // 再生中の場合
        if (_isPlaying)
        {
            // キー入力の呼び出し
            DetectKeys();
        }
    }

    // 音楽の再生
    public void StartMusic()
    {
        startButton.SetActive(false);   // 
        _audioSource.Play();            // audioSoerceオブジェクトを再生中にする
        _startTime = Time.time;         // スタート時間の作成
        _isPlaying = true;              // 再生中フラグ
    }

    // キー入力処理
    void DetectKeys()
    {
        // Dキー入力で0番ラインにノーツが発生
        if (Input.GetKeyDown(KeyCode.D))
        {
            WriteNotesTiming(0);
        }

        // Fキー入力で1番ラインにノーツが発生
        if (Input.GetKeyDown(KeyCode.F))
        {
            WriteNotesTiming(1);
        }
        
        // Jキー入力で2番ラインにノーツが発生
        if (Input.GetKeyDown(KeyCode.J))
        {
            WriteNotesTiming(2);
        }

        // Kキー入力で3番ラインにノーツが発生
        if (Input.GetKeyDown(KeyCode.K))
        {
            WriteNotesTiming(3);
        }
    }

    // ノーツが発生する時間を書き込む処理
    void WriteNotesTiming(int num)
    {
        Debug.Log(GetTiming());                                                 // デバッグの表示
        _CSVWriter.WriteCSV(GetTiming().ToString() + "," + num.ToString());     // CSVWriterクラスのWriteCSV関数呼び出し(秒数.コンマ秒 , ライン番号)
    }

    // 現在時間の取得
    float GetTiming()
    {
        return Time.time - _startTime;  // スタート時間から現在何秒経ったかを計測
    }
}