using UnityEngine;
using System.Collections;

public class BadGuy : MonoBehaviour {
	public GameObject wall;
	 
	void OnDisable(){
		wall.SetActive (true);
	}
}
