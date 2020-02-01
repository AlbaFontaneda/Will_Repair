using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private Camera _camera;

    public void ChangeScene(string scene, Vector2 spawnPoint, Vector2 cameraPosition)
    {
        if (!SceneManager.GetSceneByName(scene).isLoaded)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }

        _player.transform.position = spawnPoint;

        _camera.transform.position = cameraPosition;
    }
}
