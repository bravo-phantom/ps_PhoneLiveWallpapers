using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    [Header ("UI")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject videoPanel;
    [SerializeField] private GameObject backPanel;

    [Header ("Videos")]
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private VideoClip[] videoClip;

    [Header("Animations")]
    [SerializeField] private Animator videoPanelAnimator;
    [SerializeField] private Animator backPanelAnimator;

    private bool isVideoRunning;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        // If video is running; go back to main menu
        if (Input.GetKeyDown(KeyCode.Escape) && isVideoRunning)
        {
            StopVideo();
        }

        // If video is not running; open the back menu
        else if (Input.GetKeyDown(KeyCode.Escape) && !isVideoRunning && !backPanel.activeInHierarchy)
        {
            backPanel.SetActive(true);
        }

        //If the back menu is opened; clsoe the back menu
        else if (Input.GetKeyDown(KeyCode.Escape) && backPanel.activeInHierarchy)
        {
            OnExitNoBtnClicked();
        }
    }

    private void Initialize()
    {
        mainMenuPanel.SetActive(true);
        videoPanel.SetActive(false);
        backPanel.SetActive(false);
        isVideoRunning = false;
    }

    public void PlayVideo(int videoNumber)
    {
        // Initialize Panels
        videoPanel.SetActive(true);
        Invoke("CloseMainMenu" , 0.5f);

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
        // Start Back panel clsoe animation
        backPanelAnimator.SetTrigger("Close");

        // Clsoe back panel
        Invoke("CloseBackPanel" , 0.25f);
    }

    private void StopVideo()
    {
        // Stop Video
        videoPlayer.Stop();

        // Open main menu
        mainMenuPanel.SetActive(true);
        
        // Start clsoe animation of video panel
        videoPanelAnimator.SetTrigger("Close");

        // Close Video Panel
        Invoke("CloseVideoPanel" , 0.5f);

        // Update Data
        isVideoRunning = false;
    }

    private void CloseMainMenu()
    {
        mainMenuPanel.SetActive(false);
    }

    private void CloseVideoPanel()
    {
        videoPanel.SetActive(false);
    }

    private void CloseBackPanel()
    {
        backPanel.SetActive(false);
    }
}
