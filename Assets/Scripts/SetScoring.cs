using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScoring : MonoBehaviour
{

    public Text score;
    bool scoreSet = false;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        if (score & scoreManager & !scoreSet)
        {
            score.text = System.Math.Round(scoreManager.getScore(),2).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
