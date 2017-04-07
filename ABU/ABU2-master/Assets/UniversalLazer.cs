using UnityEngine;
using System.Collections;

public class UniversalLazer : MonoBehaviour {
	public GameObject m_Lazer;
	private float LazerTimer = 0;
	public float FireRate;
	public GameObject guy;
	public GameObject bWall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (bWall.active == true) {
			LazerTimer += Time.deltaTime;
			if (LazerTimer >= FireRate) {
				FireLazer ();
				LazerTimer = 0;
			}
		} 


	}
	void FireLazer()
	{
		GameObject newLazer = Instantiate (m_Lazer) as GameObject;
		Vector3 myPos = newLazer.transform.position;
		myPos = guy.transform.position;
		newLazer.transform.position = myPos;
		newLazer.SetActive (true);
	}
}
