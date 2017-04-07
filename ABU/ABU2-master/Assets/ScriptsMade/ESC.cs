using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class ESC : MonoBehaviour {

	private Canvas CanvasObject; // Assign in inspector
	private bool pause;

	void Start()
	{
		CanvasObject = GetComponent<Canvas> ();
		pause = true;
	}

	void Update() 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			onResume ();
		} 


	}
	public void onResume(){
		CanvasObject.enabled = !CanvasObject.enabled;

		if (pause) {
			Debug.Log ("pause");
			Time.timeScale = 0.000000000f;
			pause = false;
		} 
		else {
			Time.timeScale = 1;
			pause = true;
		}
	}
}

