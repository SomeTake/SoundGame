using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesTimingMaker : MonoBehaviour
{

    private AudioSource _audioSource;

    public GameObject StartButton;

    void Start()
    {
        _audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();

    }

    void Update()
    {

    }

    public void StartMusic()
    {
        StartButton.SetActive(false);
        _audioSource.Play();
    }
}