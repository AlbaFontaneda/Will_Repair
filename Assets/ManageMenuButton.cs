using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMenuButton : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource = null;

    private bool pressStart = false;
    private bool pressExit = false;
    private MenuManager mManager = null;

    // Start is called before the first frame update
    void Start()
    {
        mManager = gameObject.GetComponent<MenuManager>();
    }

    // Update is called once per frame
    void Update()
    {

        pressStart = Input.GetButtonDown("BotonAbajo");
        pressExit = Input.GetButtonDown("BotonDerecha");


        if (pressStart)
        {
            _audioSource.Play();
            mManager.StartGameDelay(0.3f);
        }

        if (pressExit)
        {
            _audioSource.Play();
            mManager.ExitGameDelay(0.3f);
        }

    }
}
