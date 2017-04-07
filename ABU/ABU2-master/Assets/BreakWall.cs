using UnityEngine;
using System.Collections;

public class BreakWall : MonoBehaviour {
	public GameObject[] m_ObjectsToActivate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		}
	public void goAway(){

			for(int i = 0, iMax = m_ObjectsToActivate.Length; i < iMax; i++)
			{

				m_ObjectsToActivate[i].SetActive(true);
			}
	}
}
