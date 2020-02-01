using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player = null;

    [SerializeField] private Camera _camera = null;

    public void ChangeSceneAdditive(string scene, Vector2 spawnPoint, Vector2 cameraPosition)
    {
        if (!SceneManager.GetSceneByName(scene).isLoaded)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }

        _player.transform.position = spawnPoint;

        _camera.transform.position = cameraPosition;
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
