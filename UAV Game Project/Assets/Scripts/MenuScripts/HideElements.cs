using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideElements : MonoBehaviour
{
    public GameObject inGameMenu;
    public GameObject crossHair;
    public GameObject inGameDeathMenu;
    private bool isGamePaused;
    
    public AudioSource explosionSound;
    public ParticleSystem explosion;
    
    private void Start()
    {
        isGamePaused = false;
    }

    private void Awake()
    {
        HideUIElement(inGameMenu);
        HideUIElement(inGameDeathMenu);
        ResumeGame();
    }
    private void LateUpdate()
    {
        if (isGamePaused)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                HideUIElement(inGameMenu);
                ShowUIElement(crossHair);
                ResumeGame();
                isGamePaused = false;
            }
        }
        else
        {
            if (Input.GetButtonDown("Cancel"))
            {
                ShowUIElement(inGameMenu);
                HideUIElement(crossHair);
                PauseGame();
                isGamePaused = true;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(WaitBeforeExplode());
    }
    
    private void HideUIElement(GameObject uiElement)
    {
        uiElement.SetActive(false);
    }

    private void ShowUIElement(GameObject uiElement)
    {
        uiElement.SetActive(true);
    }

    public void PauseGame ()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame ()
    {
        Time.timeScale = 1;
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
}
