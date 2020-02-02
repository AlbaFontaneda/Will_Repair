using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void StartGameDelay(float time)
    {
        Invoke("StartGame", time);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    public void ExitGameDelay(float time)
    {
        Invoke("ExitGame", time);
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToMenuDelay(float time)
    {
        Invoke("GoToMenu", time);
    }


}
