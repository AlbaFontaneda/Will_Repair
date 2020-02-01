using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    private FlyingCharacter2D m_Character;

    void Awake()
    {
        m_Character = GameObject.FindObjectOfType<FlyingCharacter2D>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Tumor");

            // activar mini juego del character
            m_Character.StartGame(this);
        }
    }

    // Destruir el tumor cuando el jugador termina el mini juego
    public void Destruir()
    {
        Destroy(this.gameObject);
    }

}
