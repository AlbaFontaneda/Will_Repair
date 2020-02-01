using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Spawn()
    {
        this.gameObject.SetActive(false);
        this.gameObject.transform.position = spawnPoint.position;
        this.gameObject.SetActive(true);
    }
}
