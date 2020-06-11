using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public GameObject LoadingScren;
    public GameObject AGLoadingScreen;
    public Slider slider;
    public void Start()
    {
        GameObject.Find("Version").GetComponent<TextMeshProUGUI>().text = Application.version;
     
    }


    public void StartGame(int sceneIndex)
    {
        StartCoroutine(Loading(sceneIndex));
    }

    public void StartAGgame(int sceneIndex)
    {
        StartCoroutine(LoadingAG(sceneIndex));
    }

    
    //Loading screen
    IEnumerator Loading(int sceneIndex)
    {
        LoadingScren.SetActive((true));
        yield return new WaitForSeconds(1);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
    
    
    IEnumerator LoadingAG(int sceneIndex)
    {
        AGLoadingScreen.SetActive((true));
        yield return new WaitForSeconds(1);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
    
    
    

    public void QuitGame() //Quit game
    {
        Debug.Log("Game Quit"); //While testing in unity, game don't really exits, so it highlight in console that function works
        Application.Quit();
    }
}