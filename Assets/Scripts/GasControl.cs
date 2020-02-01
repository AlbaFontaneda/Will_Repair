using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasControl : MonoBehaviour
{

    public float cycleTime = 3;
    public GameObject gas;
    public ParticleSystem particleSystem1;
    public ParticleSystem particleSystem2;
    public GameObject damageObject;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Cycle");
    }

    IEnumerator Cycle() {
        while (true)
        {
            gas.SetActive(false);
            gas.SetActive(true);
            damageObject.SetActive(true);
            yield return new WaitForSeconds(cycleTime);
            particleSystem1.Stop();
            particleSystem2.Stop();
            damageObject.SetActive(false);
            yield return new WaitForSeconds(cycleTime);
        }
        
    }

}
