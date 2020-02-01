using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayer : MonoBehaviour
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
            var heading = player.transform.position - transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance; //normalized object-player direction

            other.gameObject.GetComponent<MovementControl>().Pushback(direction);

        }
    }
}
