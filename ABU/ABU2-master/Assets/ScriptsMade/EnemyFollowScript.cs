using UnityEngine;
using System.Collections;

public class EnemyFollowScript : MonoBehaviour {

	public Transform FollowTargert;
	public float Speed;

	private Vector3 myPosition;

	void Start () {
		myPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (FollowTargert.position.x < myPosition.x) {
			myPosition.x -= Speed * Time.deltaTime;
		} 
		else if (FollowTargert.position.x > myPosition.x) {
			myPosition.x += Speed * Time.deltaTime;
		}
		transform.position = myPosition;
	}
}
