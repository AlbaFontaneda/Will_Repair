using System;
using UnityEngine;

public class FlyingCharacter2D : MonoBehaviour
{
    [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.

    private Rigidbody2D m_Rigidbody2D;

    private GameManager game;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        game = GameObject.FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
           
    }

    public void Move(float horizontal, float vertical)
    {
        // Move the character
        m_Rigidbody2D.velocity = new Vector2(horizontal * m_MaxSpeed, vertical * m_MaxSpeed);
    }

}
