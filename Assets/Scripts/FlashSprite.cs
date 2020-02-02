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
}
