using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 direction;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //are you Player?
        if (other.gameObject.tag == "Player")
        {
            //fuck off then
            GameObject player = other.gameObject;

            other.gameObject.GetComponent<MovementControl>().SlowMotion(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //are you Player?
        if (other.gameObject.tag == "Player")
        {
            //fuck off then
            GameObject player = other.gameObject;

            other.gameObject.GetComponent<MovementControl>().SlowMotion(false);

        }
    }
}
