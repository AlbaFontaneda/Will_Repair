using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChangeScene : MonoBehaviour
{
    private GameManager _manager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

    [SerializeField] private string _scene = null;

    [SerializeField] private Transform _spawnTransform = null;

    [SerializeField] private Transform _cameraTransform = null;

    void OnTriggerEnter()
    {
        _manager.ChangeSceneAdditive(_scene, _spawnTransform.position, _cameraTransform.position);
    }
}
