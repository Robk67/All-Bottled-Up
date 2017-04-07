using UnityEngine;
using System.Collections;

public class BlinkenThingy : MonoBehaviour {

    public float OnTime;

	void Start () {
        BlinkenOn();
	}

    void BlinkenOn()
    {
        gameObject.SetActive(true);
        Invoke("BlinkenOff", OnTime);
    }

    void BlinkenOff()
    {
        gameObject.SetActive(false);
        Invoke("BlinkenOn", OnTime);
    }
}
