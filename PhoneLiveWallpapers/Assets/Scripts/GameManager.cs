using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    [Header ("UI")]
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject videoCanvas;
    [SerializeField] private GameObject backCanvas;

    [Header ("Videos")]
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private VideoClip[] videoClip;

    private bool isVideoRunning;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        //if (Application.platform == RuntimePlatform.Android)
        //{
            // If video is running; go back to main menu
            if (Input.GetKeyDown(KeyCode.Escape) && isVideoRunning)
            {
                StopVideo();
            }

            // If video is not running; open the back menu
            else if (Input.GetKeyDown(KeyCode.Escape) && !isVideoRunning && !backCanvas.activeInHierarchy)
            {
                backCanvas.SetActive(true);
            }
        //}
    }

    private void Initialize()
    {
        mainCanvas.SetActive(true);
        videoCanvas.SetActive(false);
        backCanvas.SetActive(false);
        isVideoRunning = false;
    }

    public void PlayVideo(int videoNumber)
    {
        // Initialize Canvas
        videoCanvas.SetActive(true);
        mainCanvas.SetActive(false);

        // Update Data
        isVideoRunning = true;

        // Set Video on Video Player
        videoPlayer.clip = videoClip[videoNumber-1];

        // Start Video
        videoPlayer.Play();
    }

    public void OnExitYesBtnClicked()
    {
        Application.Quit();
    }

    public void OnExitNoBtnClicked()
    {
        backCanvas.SetActive(false);
    }

    private void StopVideo()
    {
        // Stop Video
        videoPlayer.Stop();

        // Go back to main menu
        mainCanvas.SetActive(true);
        videoCanvas.SetActive(false);

        // Update Data
        isVideoRunning = false;
    }
}
