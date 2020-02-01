using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public Zona zona;

    private GameManager game;

    void Awake()
    {
        game = GameObject.FindObjectOfType<GameManager>();
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
            FlyingCharacter2D m_Character = other.GetComponent<FlyingCharacter2D>();

            // activar mini juego del character
            //m_Character.StartGame(this);
            game.RepairCurrentTumor();
        }
    }

}
