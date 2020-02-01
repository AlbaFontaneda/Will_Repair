using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    /*Uses Thaleah Font from the AssetStore*/

    float timeLeft = 300.0f;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        float seconds = Mathf.Round(timeLeft);

        text.text = ((int)(seconds/60)).ToString().PadLeft(2, '0') + ":"+(seconds%60).ToString().PadLeft(2, '0');
        if (timeLeft < 0)
        {
            Application.LoadLevel("gameOver");
        }
    }
}
