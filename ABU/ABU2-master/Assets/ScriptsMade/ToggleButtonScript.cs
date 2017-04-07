using UnityEngine;
using System.Collections;
using System;

public class ToggleButtonScript : ActivatableScript {

    public GameObject[] ObjectsToToggle;

    public override void RunActivatableScript()
    {
        for(int i = 0, iMax = ObjectsToToggle.Length; i < iMax; i++)
        {
            ObjectsToToggle[i].SetActive(!ObjectsToToggle[i].activeSelf);
        }
    }

}
