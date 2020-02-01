using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECGScript : MonoBehaviour
{

    /*
     * Inspired by https://docs.unity3d.com/ScriptReference/LineRenderer.SetPosition.html
     * Data from https://www.kaggle.com/shayanfazeli/heartbeat#ptbdb_normal.csv
     */

    // Creates a line renderer that follows a Sin() function
    // and animates it.
    public Color dark_ok = Color.green;
    public Color dark_bad = Color.red;
    public Color clear = Color.white;
    public int lengthOfLineRenderer = 100;
    public int speedMultiplier = 20;
    public float scaleDivisor = 1.8f;
    public float widthScale = 0.02f;
    public int criticalTime = 60;

    public float positionX = -8.2f;
    public float positionY = 3;

    CountDown countDown;

    Gradient gradient_ok;
    Gradient gradient_bad;

    public float[] ecgpoints = {
        1.0f,0.9003f,0.3586f,0.0515f,0.0466f,0.1268f,0.1333f,0.1191f,0.1106f,0.113f,
        0.1066f,0.107f,0.1159f,0.1224f,0.1224f,0.1195f,0.1159f,0.1224f,0.126f,0.1337f,
        0.1349f,0.1426f,0.1511f,0.1584f,0.1637f,0.1738f,0.1888f,0.2079f,0.231f,0.2585f,
        0.2946f,0.3258f,0.3626f,0.3983f,0.4295f,0.4494f,0.451f,0.419f,0.3728f,0.3104f,
        0.25f,0.2042f,0.169f,0.1475f,0.1305f,0.1244f,0.1175f,0.1167f,0.1159f,0.1187f,
        0.1155f,0.1139f,0.1195f,0.1167f,0.1228f,0.1207f,0.1167f,0.1228f,0.1264f,0.1317f,
        0.1418f,0.1394f,0.1451f,0.1434f,0.141f,0.1406f,0.1382f,0.137f,0.1321f,0.1284f,
        0.1284f,0.128f,0.1252f,0.1224f,0.1171f,0.1126f,0.113f,0.1276f,0.1653f,0.1795f,
        0.1613f,0.1767f,0.1827f,0.1746f,0.1515f,0.1479f,0.1349f,0.1228f,0.107f,0.0981f,
        0.0944f,0.0891f,0.0891f,0.0887f,0.0908f,0.0859f,0.0859f,0.0891f,0.0843f,0.0579f,
    };


    // Start is called before the first frame update
    void Start()
    {
        countDown = gameObject.GetComponent(typeof(CountDown)) as CountDown;

        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.05f;
        lineRenderer.positionCount = lengthOfLineRenderer;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;

        gradient_ok = new Gradient();
        gradient_bad = new Gradient();
        gradient_ok.SetKeys(
            new GradientColorKey[] { new GradientColorKey(dark_ok, 0.0f), new GradientColorKey(clear, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        gradient_bad.SetKeys(
            new GradientColorKey[] { new GradientColorKey(dark_bad, 0.0f), new GradientColorKey(clear, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        //lineRenderer.colorGradient = gradient_ok;
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        var t = Time.time;
        if (countDown != null) {
            if (countDown.timeLeft < criticalTime) {
                lineRenderer.colorGradient = gradient_bad;
                for (int i = 0; i < lengthOfLineRenderer; i++)
                {
                    lineRenderer.SetPosition(i, new Vector3(i * widthScale + positionX,
                        ecgpoints[((int)(i + t * speedMultiplier*2) % lengthOfLineRenderer)] / scaleDivisor + positionY,
                        0.0f));

                }
            }
            else
            {
                lineRenderer.colorGradient = gradient_ok;
                for (int i = 0; i < lengthOfLineRenderer; i++)
                {
                    lineRenderer.SetPosition(i, new Vector3(i * widthScale + positionX,
                        ecgpoints[((int)(i + t * speedMultiplier) % lengthOfLineRenderer)] / scaleDivisor + positionY,
                        0.0f));

                }
            }
        }

    }
}
