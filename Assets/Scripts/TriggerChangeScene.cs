using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChangeScene : MonoBehaviour
{
    private GameManager _manager = null;

    [SerializeField] private string _scene = null;

    [SerializeField] private Transform _spawnTransform = null;

    [SerializeField] private Transform _cameraTransform = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        _manager.ChangeSceneAdditive(_scene, _spawnTransform.position, _cameraTransform.position);
    }

    void Awake()
    {
        _manager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
}
