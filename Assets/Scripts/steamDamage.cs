﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steamDamage : MonoBehaviour
{
    private FlashSprite flashSprite;
 
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Matar al nanobot");
        GameObject colObject = col.gameObject;
        if (colObject.gameObject.tag == "Player")
        {
            
            FlashSprite flashSprite = colObject.GetComponent<FlashSprite>();

            flashSprite.enabledFlash(true);
        }
        
    }
}
