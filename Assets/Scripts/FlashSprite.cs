using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSprite : MonoBehaviour
{
    bool flashed = false;

    public void enabledFlash(bool enable) {
        flashed = enable;
        this.gameObject.GetComponent<Death>().Spawn();
    }

    /*int delay = 2;
    public SpriteRenderer mySpriteRenderer;
    int counter;
    bool toggle = false;
    int deathCounter = 0;*/

    //old shit

    /*void FixedUpdate()    // you can you FixedUpdate for fixed flash rate
    {
        Flash(mySpriteRenderer);

        if (deathCounter > 0)
        {
            mySpriteRenderer.enabled = true;
            deathCounter = 0;
            Death death = this.gameObject.GetComponent<Death>();
            death.Spawn();
        }
    }*/

    /*void Flash(SpriteRenderer spriteRen)
    {

        if (flashed)
        {
            if (counter >= delay)
            {
                deathCounter++;
                counter = 0;

                toggle = !toggle;
                if (toggle)
                {
                    spriteRen.enabled = true;
                }
                else
                {
                    spriteRen.enabled = false;
                }

            }
            else
            {
                counter++;
            }
        }
        
    }*/

}
