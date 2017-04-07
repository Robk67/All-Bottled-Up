using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	
	public Animator playerA;
	public GameObject player;
	private bool turnOn;
	// Use this for initialization
	void Start () {
		playerA = player.GetComponent<Animator>();
		turnOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
			turnOn = true;
			animationOn (turnOn);
		} 
		else if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {
			turnOn = false;
			animationOn (turnOn);
		}
	}

			void animationOn( bool temp){
		if (temp == true) {
			playerA.enabled = !playerA.enabled;
		} else {
			playerA.enabled = false;
		}
			}

}
