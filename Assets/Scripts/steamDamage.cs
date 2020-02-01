using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steamDamage : MonoBehaviour
{
    private FlashSprite flashSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    // Nah, que si nos tocan una vez muramos
    /*void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Matar al nanobot");
        GameObject colObject = col.gameObject;
        if (colObject.gameObject.tag == "Player")
        {
            
            FlashSprite flashSprite = colObject.GetComponent<FlashSprite>();

            flashSprite.enabledFlash(false);
        }

    }*/
}
