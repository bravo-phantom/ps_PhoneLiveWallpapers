using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    [Header ("UI")]
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject videoCanvas;

    [Header ("Videos")]
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private VideoClip[] videoClip;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        mainCanvas.SetActive(true);
        videoCanvas.SetActive(false);
    }

    public void PlayVideo(int videoNumber)
    {
        // Initialize Canvas
        videoCanvas.SetActive(true);
        mainCanvas.SetActive(false);

        // Set Video on Video Player
        videoPlayer.clip = videoClip[videoNumber-1];

        // Start Video
        videoPlayer.Play();
    }
}
