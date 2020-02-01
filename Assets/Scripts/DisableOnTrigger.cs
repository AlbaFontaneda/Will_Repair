using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(DisableOnEndOfFrame());
    }

    private IEnumerator DisableOnEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        this.gameObject.SetActive(false);
    }
}
