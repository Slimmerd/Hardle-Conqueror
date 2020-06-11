using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fml : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool IsDeath;

    public static GameObject gameOverText;
    public int CurntLevel;

    private void Awake()
    {
        gameOverText =
            GameObject.Find(
                "gameOverUI"); //Finds gameobject called GameOver and makes variable gameovertext equal to it
    }

    private void Start()
    {
        IsDeath = false;
        Time.timeScale = 1;
        if (gameOverText.activeSelf == true) gameOverText.SetActive(false);
    }

    public void Retry() //Retry button function
    {
        StartCoroutine(RetryGame());

        IEnumerator RetryGame()
        {
            yield return new WaitForSecondsRealtime(0.2f);
            SceneManager.LoadScene(CurntLevel);
        }
    }

    public void Menu() //Menu button function
    {
        StartCoroutine(GameMenu());

        IEnumerator GameMenu()
        {
            yield return new WaitForSecondsRealtime(0.2f);
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}