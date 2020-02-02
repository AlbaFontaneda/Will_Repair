using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] Transform spawnPoint = null;
    [SerializeField] public AudioClip _audioClip = null;

    private SpriteRenderer spriteRenderer;
    private MovementControl movementControl;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        movementControl = gameObject.GetComponent<MovementControl>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Spawn()
    {
        audioSource.clip = _audioClip;
        audioSource.Play();
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

        movementControl.ResetMovement();
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(.1f);
    }
}
