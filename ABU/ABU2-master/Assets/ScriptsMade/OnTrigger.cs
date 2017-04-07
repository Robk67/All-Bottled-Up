using UnityEngine;
using System.Collections;

public class OnTrigger : MonoBehaviour {

	 void Update(){
		if(Input.GetKeyDown(KeyCode.Q)){
			Debug.Log ("Game Over");
		}
	}

}
