using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideElements : MonoBehaviour
{
    [Header("Menu Objects")]
    public GameObject inGameMenu;
    public GameObject crossHair;
    public GameObject inGameDeathMenu;
    public GameObject inGameWinMenu;
    private bool isGamePaused;
    
    [Header("Explosion")]
    public AudioSource explosionSound;
    public ParticleSystem explosion;

    [Header("Win conditions")]
    public bool winCondition;

    [Header("Propeller Sound")] 
    public AudioSource propellerSound;

    
    private Menu menu;
    private Shoot shoot;
    
    private void Start()
    {
        isGamePaused = false;
    }

    private void Awake()
    {
        menu = FindObjectOfType<Menu>();
        shoot = GetComponentInChildren<Shoot>();
        
        HideUIElement(inGameMenu);
        HideUIElement(inGameDeathMenu);
        HideUIElement(inGameWinMenu);
        ResumeGame();
    }
    private void LateUpdate()
    {
        CheckWinCondition();
        
        if (winCondition)
        {
            StartCoroutine(WaitBeforeWin());
        }
        else
        {
            if (isGamePaused)
            {
                if (Input.GetButtonDown("Cancel"))
                {
                    HideUIElement(inGameMenu);
                    ShowUIElement(crossHair);
                    ResumeGame();
                }
            }
            else
            {
                if (Input.GetButtonDown("Cancel"))
                {
                    ShowUIElement(inGameMenu);
                    HideUIElement(crossHair);
                    PauseGame();
                }
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(WaitBeforeExplode());
    }
    
    public void HideUIElement(GameObject uiElement)
    {
        uiElement.SetActive(false);
    }

    public void ShowUIElement(GameObject uiElement)
    {
        uiElement.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isGamePaused = true;
    }
    public void ResumeGame ()
    {
        Time.timeScale = 1;
        isGamePaused = false;
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
    
    private IEnumerator WaitBeforeExplode()
    {
        explosion.Play();
        explosionSound.Play();
        ShowUIElement(inGameDeathMenu);
        yield return new WaitForSeconds(1);
        Kill();
    }
    
    private IEnumerator WaitBeforeWin()
    {
        ShowUIElement(inGameWinMenu);
        yield return new WaitForSeconds(4);
        menu.IntoMainMenu();
    }

    private void CheckWinCondition()
    {
        if (shoot.destroyedTanksCounter >= 5)
        {
            winCondition = true;
        }
        else
        {
            winCondition = false;
        }
    }
}
