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

        GameObject colObject = col.gameObject;
        if (colObject.gameObject.tag == "Player")
        {
            Debug.Log("Matar al nanobot");
            FlashSprite flashSprite = colObject.GetComponent<FlashSprite>();

            flashSprite.enabledFlash(true);
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {

        GameObject colObject = col.gameObject;
        if (colObject.gameObject.tag == "Player")
        {
            Debug.Log("Matar al nanobot");
            FlashSprite flashSprite = colObject.GetComponent<FlashSprite>();

            flashSprite.enabledFlash(false);
        }

    }
}
