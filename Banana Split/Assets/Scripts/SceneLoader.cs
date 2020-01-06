using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    
    [SerializeField] float timeToWait = 3f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& SceneManager.GetActiveScene().buildIndex != 0)
        {
            LoadMainMenu();
        }

        if(Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            RestarNoWait();
        }
    }
    public void LoadNextLevel()
    {
        if (SceneManager.sceneCountInBuildSettings - 1 != SceneManager.GetActiveScene().buildIndex) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            LoadMainMenu();
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        StartCoroutine(Restart());
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 

    public void RestarNoWait()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
