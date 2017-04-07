using UnityEngine;
using System.Collections;
using System;

public class TimedButtonScript : ActivatableScript
{

    public GameObject[] ObjectsToActivate;
    public float SecondsToActivate;

    public override void RunActivatableScript()
    {
        for(int i = 0, iMax = ObjectsToActivate.Length; i < iMax; i++)
        {
            ObjectsToActivate[i].SetActive(true);
        }

        Invoke("DisableObjects", SecondsToActivate);
    }

    void DisableObjects()
    {
        for (int i = 0, iMax = ObjectsToActivate.Length; i < iMax; i++)
        {
            ObjectsToActivate[i].SetActive(false);
        }
    }
}
