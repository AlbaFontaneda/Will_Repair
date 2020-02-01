using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] Transform spawnPoint = null;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Spawn()
    {
        StartCoroutine("FlashSpriteBeforeDeath");
        
    }

    IEnumerator FlashSpriteBeforeDeath()
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(.05f);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(.05f);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(.05f);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(.05f);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(.05f);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(.05f);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(.05f);

        this.gameObject.SetActive(false);
        this.gameObject.transform.position = spawnPoint.position;
        this.gameObject.SetActive(true);

        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(.1f);
    }
}
