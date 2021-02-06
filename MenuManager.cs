using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject titleMenu, helpScreen;
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] PlayerMovement player;
    [SerializeField] GameObject gameHUD, pauseScreen;
    bool help;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }
    private void Start()
    {
        player.enabled = false;
    }
    public void ゲームースタト()
    {
        titleMenu.SetActive(false);
        cam.LookAt = PlayerMovement.Instance.transform;
        player.enabled = true;
        gameHUD.SetActive(true);
    }

    public void HelpScreen()
    {
        if (help)
        {
            help = false;
            helpScreen.SetActive(false);
            titleMenu.SetActive(true);
        }
        else
        {
            help = true;
            helpScreen.SetActive(true);
            titleMenu.SetActive(false);
        }
    }

    public void FullScreen()
    {
        if (Screen.fullScreen)
        {
            Screen.SetResolution(900, 700, false, 60);
        }
        else
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true, 60);
        }
        
    }

    public void PauseMenu()
    {
        pauseScreen.SetActive(!pauseScreen.activeSelf);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
