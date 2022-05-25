using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideElements : MonoBehaviour
{
    public GameObject inGameMenu;
    public GameObject crossHair;
    private bool isGamePaused;
    
    private void Start()
    {
        isGamePaused = false;
    }

    private void Awake()
    {
        HideMenu();
        ResumeGame();
    }
    private void LateUpdate()
    {
        if (isGamePaused)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                HideMenu();
                ResumeGame();
                isGamePaused = false;
            }
        }
        else
        {
            if (Input.GetButtonDown("Cancel"))
            {
                ShowMenu();
                PauseGame();
                isGamePaused = true;
            }
        }
    }
    
    
    
    public void HideMenu()
    {
        inGameMenu.SetActive(false);
        crossHair.SetActive(true);
    }

    public void ShowMenu()
    {
        inGameMenu.SetActive(true);
        crossHair.SetActive(false);
    }
    
    public void PauseGame ()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
