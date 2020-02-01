using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSequencer : MonoBehaviour
{

    public enum eButtons { UP, DOWN, LEFT, RIGHT };
    public enum eStatus { BASE, OK, KO };


    public Sprite[] upSprites;
    public Sprite[] downSprites;
    public Sprite[] leftSprites;
    public Sprite[] rightSprites;

    public Image[] iButtons;
    public int[] sequence = { 0, 0, 0, 0 };
    int currentIndex = 0;

    int sequenceSize;
    // Start is called before the first frame update
    void Start()
    {
        sequenceSize = iButtons.Length;
        hideSequence();
    }

    // Update is called once per frame
    void Update()
    {        
    }

    public void createSequence()
    {
        for (int i=0; i< sequenceSize; ++i) 
            sequence[i] = Random.Range(0, sequenceSize);
        showSequence();
    }
    public void showSequence()
    {
        //for (int i = 0; i < sequenceSize; ++i)
        //showButton(i, sequence[i], eStatus.BASE);
        //StartCoroutine(showButton(i, sequence[i], eStatus.BASE));
        StartCoroutine(showButtons(.5f));
    }

    public void hideSequence()
    {
        for (int i = 0; i < sequenceSize; ++i)
            hideButton(i);
    }

    public void resetSequence()
    {
        hideSequence();
        createSequence();
    }

    IEnumerator showButtons(float time)
    {
        WaitForSeconds wait = new WaitForSeconds(time);
        for (int i = 0; i < sequenceSize; ++i){      
            //Start the coroutine we define below named ExampleCoroutine.
            yield return wait;
            updateButton(i, sequence[i], eStatus.BASE);
        }
    }

    public void updateButton(int indexButton, int indexDirection, eStatus status)
    {
        // Asignar el sprite correspondiente segun direccion y estado
        switch (sequence[indexButton])
        {
            case 0:
                iButtons[indexButton].sprite = upSprites[(int)status];
                break;
            case 1:
                iButtons[indexButton].sprite = downSprites[(int)status];
                break;
            case 2:
                iButtons[indexButton].sprite = leftSprites[(int)status];
                break;
            case 3:
                iButtons[indexButton].sprite = rightSprites[(int)status];
                break;
        }

        iButtons[indexButton].enabled = true;
    }

    public void hideButton(int indexButton)
    {
        iButtons[indexButton].enabled = false;
    }

    public bool checkPressedButton(eButtons button)
    {
        bool result = false;
        if(button == (eButtons)sequence[currentIndex])
        {
            //OK
            //StartCoroutine(showButton(currentIndex, sequence[currentIndex], eStatus.OK));
            updateButton(currentIndex, sequence[currentIndex], eStatus.OK);
        }
        else
        {
            //KO
            //Mostrar error x segundos
            //StartCoroutine(showButton(currentIndex, sequence[currentIndex], eStatus.KO));
            updateButton(currentIndex, sequence[currentIndex], eStatus.KO);
            //Resetear codigo
            resetSequence();
        }
        return result;
    }
    /*
    IEnumerator WaitCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2f);
    }
    */
}
