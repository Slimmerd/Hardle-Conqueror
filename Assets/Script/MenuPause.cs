using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pausedMenuUI;
    private SoundManagement audioManager; //Import AudioManager
    private bool _isDeath;

    private void Start()
    {
        audioManager = SoundManagement.instance; //Import AudioManager
        _isDeath = false;

    }

    private void Update() //On press ESCAPE starts resume/pause function
    {
        if (SceneManager.GetActiveScene().name == "Aggressive")
        {
            _isDeath = MoveContrl.Pdead;
        }
        else
        {
            _isDeath = GroundObstacleDeath.IsDeath;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && (_isDeath==false))
        {
            if (GamePaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume() //Button RESUME function
    {
        audioManager.PlaySound("Click");
        pausedMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    private void Pause() //Pause function
    {
        pausedMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void Menu() //Button MENU function
    {
        audioManager.PlaySound("Click");
        StartCoroutine(MenuGame());
        GamePaused = false;

        IEnumerator MenuGame()
        {
            yield return new WaitForSecondsRealtime(0.2f);
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}