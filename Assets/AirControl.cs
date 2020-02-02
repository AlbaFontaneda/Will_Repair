using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirControl : MonoBehaviour
{

    public float cycleTime = 2;
    public GameObject air;
    public ParticleSystem particleSystem1;
    public GameObject collision;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Cycle");
    }

    IEnumerator Cycle()
    {
        while (true)
        {
            air.SetActive(false);
            air.SetActive(true);
            collision.SetActive(true);
            yield return new WaitForSeconds(cycleTime);
            particleSystem1.Stop();
            collision.SetActive(false);
            yield return new WaitForSeconds(cycleTime);
        }

    }

}
