using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundObstacleDeath : MonoBehaviour
{
    public static bool IsDeath;

    private GameObject gameOverText;
    private SoundManagement audioManager;


    private void Start()
    {
        IsDeath = false;
        audioManager = SoundManagement.instance;
    }


    public void OnTriggerEnter2D(Collider2D collision) //Die function
    {
        audioManager.PlaySound("Die");
        IsDeath = true;
        fml.gameOverText.SetActive(true);
        Time.timeScale = 0;
    }
}