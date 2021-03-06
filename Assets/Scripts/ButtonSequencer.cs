﻿using System.Collections;
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

    private bool sequenceCreated = false;
    private bool sequenceCompleted = false;
    private bool isSequenceInit = false;
    private bool isXAxisInUse = false;
    private bool isYAxisInUse = false;

    int sequenceSize;

    private GameManager game;

    void Awake()
    {
        game = GameObject.FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        sequenceSize = iButtons.Length;
        hideSequence();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSequenceInit)
        {
            float dpadX = Input.GetAxis("DPadX");
            float dpadY = Input.GetAxis("DpadY");

            if (Input.anyKeyDown)
            {
                bool result = false;

                if (Input.GetButtonDown("BotonArriba")) result = checkPressedButton(eButtons.UP);
                else if (Input.GetButtonDown("BotonAbajo")) result = checkPressedButton(eButtons.DOWN);
                else if (Input.GetButtonDown("BotonIzquierda")) result = checkPressedButton(eButtons.LEFT);
                else if (Input.GetButtonDown("BotonDerecha")) result = checkPressedButton(eButtons.RIGHT);

                manageSequence(result);
            }


            if (dpadY != 0)
            {
                if (!isYAxisInUse && dpadY == 1)
                {
                    Debug.Log("up");
                    isYAxisInUse = true;
                    bool result = checkPressedButton(eButtons.UP);
                    manageSequence(result);
                }
                else if (!isYAxisInUse && dpadY == -1)
                {
                    Debug.Log("down");
                    isYAxisInUse = true;
                    bool result = checkPressedButton(eButtons.DOWN);
                    manageSequence(result);
                }
            }
            else
            {
                isYAxisInUse = false;
            }

            if (dpadX != 0)
            {
                if (!isXAxisInUse && dpadX == -1)
                {
                    Debug.Log("left");
                    isXAxisInUse = true;
                    bool result = checkPressedButton(eButtons.LEFT);
                    manageSequence(result);
                }
                else if (!isXAxisInUse && dpadX == 1)
                {
                    Debug.Log("right");
                    isXAxisInUse = true;
                    bool result = checkPressedButton(eButtons.RIGHT);
                    manageSequence(result);
                }
            }
            else
            {
                isXAxisInUse = false;
            }
        }

    }

    private void manageSequence(bool result)
    {
        Debug.Log(result + " " + currentIndex + " " + sequenceSize);

        // Si hemos completado la secuencia
        if (result && currentIndex == sequenceSize)
        {
            sequenceCompleted = true;
            hideSequence();

            // Avisar al GameManager de que el jugador ha completado la secuencia
            game.RepairCurrentTumor();
        }

    }

    public void createSequence()
    {
        isSequenceInit = true;
        currentIndex = 0;
        sequenceCompleted = false;
        for (int i = 0; i < sequenceSize; ++i)
        {
            sequence[i] = Random.Range(0, sequenceSize);
        }
        //Debug.Log("Secuencia no creada", this);
        showSequence();
        //Debug.Log("Secuencia creada", this);
    }
    public void showSequence()
    {
        StartCoroutine(showButtons(.1f));
    }

    public void hideSequence()
    {
        isSequenceInit = false;
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

        sequenceCreated = true;
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
            game.soundSequence(false);
            updateButton(currentIndex, sequence[currentIndex], eStatus.OK);
            currentIndex++;
            result = true;
        }
        else
        {
            //KO
            //Meter un delay
            StartCoroutine(delayOnError(.5f));

        }
        return result;
    }

    IEnumerator delayOnError(float time)
    {
        game.soundSequence(true);
        //Mostrar error x segundos
        updateButton(currentIndex, sequence[currentIndex], eStatus.KO);
        //Start the coroutine we define below named ExampleCoroutine.
        yield return new WaitForSeconds(time);
        //Resetear codigo
        resetSequence();
    }
}
