using UnityEngine;
using System.Collections;

public class TurnYellowGuy : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("YellowGuy"))
        {
            other.GetComponent<Runner>().Flip();
        }
    }

}
