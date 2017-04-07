using UnityEngine;
using System.Collections;

public class EnablingButtonScript : ActivatableScript {

    public GameObject[] m_ObjectsToActivate;

    public override void RunActivatableScript()
    {
        for(int i = 0, iMax = m_ObjectsToActivate.Length; i < iMax; i++)
        {
            m_ObjectsToActivate[i].SetActive(true);
        }
    }
	
}
