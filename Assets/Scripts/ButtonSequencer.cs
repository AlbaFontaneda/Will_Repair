using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSequencer : MonoBehaviour
{

    public enum eButtons { UP, DOWN, LEFT, RIGHT };
    public Image[] iButtons;
    public int[] sequence = { 0, 0, 0, 0 };


    int sizeSequence;
    /*
    // Start is called before the first frame update
    void Start()
    {
        sizeSequence = System.Enum.GetNames(typeof(buttons)).Length;
        startingPoint = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {        
    }

    public void createSequence()
    {
        for (int i=0; i< sizeSequence; ++i) 
            sequence[i] = Random.Range(0, sizeSequence);
    }
    public void showSequence()
    {
        for (int i = 0; i < sizeSequence; ++i)
            showButton(i, sequence[i]);
    }

    public void hideSequence()
    {
        for (int i = 0; i < sizeSequence; ++i)
            showButton(sequence[i], startingPoint + new Vector3(0f, i * (buttonHeight + buttonMargin), 0f));
    }

    public void resetSequence()
    {
        showSequence();
    }

    public void showButton(int indexButton, Vector3 pos)
    {

    }
    public void hideButton(int i)
    {

    }
    */
}
