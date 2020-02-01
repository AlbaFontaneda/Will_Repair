﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    /*Uses Thaleah Font from the AssetStore*/

    public float timeLeft = 70.0f;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        float seconds = Mathf.Round(timeLeft);

        Blink blink = GameObject.FindGameObjectsWithTag("Warning")[0].GetComponent<Blink>();

        /*
        Cerebro: -80, -50
        Corazon: -80, -150
        Pulmones: -150, -150
        Estómago: -120, -200
        Intestinos: -75, -230
            */

        //To make the warning sign blink on the minimap
        if (seconds == 60)
        {
            blink.StartBlink(-80f, -50f);
        }
        if (seconds == 58)
        {
            blink.StopBlink(false);
        }

        text.text = ((int)(seconds/60)).ToString().PadLeft(2, '0') + ":"+(seconds%60).ToString().PadLeft(2, '0');
        if (timeLeft < 0)
        {
            Application.LoadLevel("gameOver");
        }
    }
}