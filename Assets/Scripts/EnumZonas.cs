using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumZonas : MonoBehaviour
{
    /*
    Cerebro: -80, -50
    Corazon: -80, -150
    Pulmones: -150, -150
    Estomago: -120, -200
    Intestinos: -75, -230
    */

    public enum Zona {Cerebro, Corazon, Pulmones, Estomago, Intestinos};

    public Vector2 Direction(Zona zona)
    {
        Vector2 posicion = new Vector2(0f, 0f);

        if (zona == Zona.Cerebro)
        {
            posicion = new Vector2(-80f, -50f);
        }
        else if (zona == Zona.Corazon)
        {
            posicion = new Vector2(-80f, -150f);
        }
        else if (zona == Zona.Pulmones)
        {
            posicion = new Vector2(-150f, -150f);
        }
        else if (zona == Zona.Estomago)
        {
            posicion = new Vector2(-120f, -200f);
        }
        else if (zona == Zona.Intestinos)
        {
            posicion = new Vector2(-75f, -230f);
        }

        return posicion;
    }
}
