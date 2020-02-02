using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public float score = 0f;

    void Awake()
    {
        GameObject.DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        resetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToScore(float n)
    {
        score += n;
    }
    public void resetScore()
    {
        score = 0;
    }

    public float getScore()
    {
        return score;
    }
}
