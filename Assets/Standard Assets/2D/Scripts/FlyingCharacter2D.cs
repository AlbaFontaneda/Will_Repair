using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class FlyingCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.

        private Rigidbody2D m_Rigidbody2D;

        private void Awake()
        {
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
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
}
