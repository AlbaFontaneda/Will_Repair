using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSprite : MonoBehaviour
{
    int delay = 2;
    public SpriteRenderer mySpriteRenderer;
    int counter;
    bool flashed = false;
    bool toggle = false;

    void FixedUpdate()    // you can you FixedUpdate for fixed flash rate
    {
            Flash(mySpriteRenderer);
    }

   public void enabledFlash(bool enable) {
        flashed = enable;
    }


    void Flash(SpriteRenderer spriteRen)
    {

        if (flashed)
        {
            if (counter >= delay)
            {
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
        
    }

}
