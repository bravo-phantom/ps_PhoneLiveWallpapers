using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class CheatCode : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject videoPanel;
    [SerializeField] private GameObject backPanel;

    [Header("Videos")]
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private VideoClip[] videoClip;

    [Header("Animations")]
    [SerializeField] private Animator videoPanelAnimator;
    [SerializeField] private Animator backPanelAnimator;
    public AudioSource audioSource;

    private bool isVideoRunning;

    private void Awake()
    {
        Initialize();
        StopPhoneSleeping();
        CapFrameRate();
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
        Invoke("CloseMainMenu", 0.5f);

        // Update Data
        isVideoRunning = true;

        // Set Video on Video Player
        videoPlayer.clip = videoClip[videoNumber - 1];

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
        Invoke("CloseBackPanel", 0.25f);
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
        Invoke("CloseVideoPanel", 0.5f);

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

    private void StopPhoneSleeping()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void CapFrameRate()
    {
        Application.targetFrameRate = 30;
    }

    private string[] cheatCode;
    private int index;

    void Start()
    {
        // Code is "NewVideo", IF USER PRESSES THIS; THE CURRENT VIDEO WILL END
        cheatCode = new string[] { "n", "e", "w", "v", "i" , "d" , "e" , "o"};
        index = 0;
    }

    void Update()
    {

        /*// If video is running; go back to main menu
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
        }*/


        // Check if any key is pressed
        if (Input.anyKeyDown)
        {
            // Check if the next key in the code is pressed
            if (Input.GetKeyDown(cheatCode[index]))
            {
                // Add 1 to index to check the next key in the code
                index++;
    
            }
            
            // Wrong key entered, we reset code typing
            else
            {
                index = 0;
            }
        }

        // If index reaches the length of the cheatCode string, 
        // the entire code was correctly entered
        if (index == cheatCode.Length)
        {
            // Cheat code successfully inputted!
            Time.timeScale = 1;
            StopVideo();
            audioSource.Play();

            index = 0;
        }
    }
}