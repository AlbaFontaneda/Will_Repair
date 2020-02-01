using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
// this is the UI.Text or other UI element you want to toggle
     public MaskableGraphic imageToToggle;
 
     public float interval = 0.2f;
     public float duration = 2f;
     public float startDelay = 0.5f;
     public bool currentState = true;
     public bool defaultState = true;
     bool isBlinking = false;
 
     public AudioClip clip;
     RectTransform m_RectTransform;

    void Start()
     {
         imageToToggle.enabled = defaultState;
         m_RectTransform = GetComponent<RectTransform>();
        //StartBlink();
    }
 
     public void StartBlink(float m_XAxis, float m_YAxis)
     {
         // do not invoke the blink twice - needed if you need to start the blink from an external object
         if (isBlinking)
             return;
 
         if (imageToToggle !=null)
         {
             isBlinking = true;
            //imageToToggle.transform.localPosition = position;
            //Change the RectTransform's anchored positions depending on the Slider values
            m_RectTransform.anchoredPosition = new Vector2(m_XAxis, m_YAxis);
            InvokeRepeating("ToggleState", startDelay, interval);
         }
     }
 
    public void StopBlink(bool show=true)
    {
        CancelInvoke();
        isBlinking = false;
        if (!show) { imageToToggle.enabled = false; }
        else { imageToToggle.enabled = true; }
    }

     public void ToggleState()
     {
         imageToToggle.enabled = !imageToToggle.enabled;
 
         // plays the clip at (0,0,0)
         if (clip)
             AudioSource.PlayClipAtPoint(clip,Vector3.zero);
     }
}
