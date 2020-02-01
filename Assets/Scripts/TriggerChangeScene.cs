using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChangeScene : MonoBehaviour
{
    private GameManager _manager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

    [SerializeField] private string _scene;

    [SerializeField] private Transform _spawnTransform;

    [SerializeField] private Transform _cameraTransform;

    void OnTriggerEnter()
    {
        _manager.ChangeScene(_scene, _spawnTransform.position, _cameraTransform.position);
    }
}
