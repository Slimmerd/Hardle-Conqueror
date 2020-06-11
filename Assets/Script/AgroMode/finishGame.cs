using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishGame : MonoBehaviour
{

    private GameObject gameFinishText;
    private SoundManagement audioManager;

    private void Awake()
    {
        gameFinishText =
            GameObject.Find(
                "gameFinishUI"); //Finds gameobject called GameOver and makes variable gameovertext equal to it
    }

    private void Start()
    {
        if (gameFinishText.activeSelf == true) gameFinishText.SetActive(false);
        audioManager = SoundManagement.instance;
    }
    


    public void OnTriggerEnter2D(Collider2D collision) //Die function
    {
        audioManager.PlaySound("Coin");
        
        gameFinishText.SetActive(true);
        Time.timeScale = 0;
    }
}
