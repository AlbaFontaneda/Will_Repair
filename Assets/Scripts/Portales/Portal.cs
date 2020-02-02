using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Vector3 spawnPosition;

    void Awake()
    {
        spawnPosition = transform.GetChild(0).position;
    }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // teleport
            other.gameObject.transform.position = spawnPosition;
        }
    }

}
