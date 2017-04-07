using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviour {
	public float distance = 2f;
	private MeshRenderer textMesh;
	public Transform player;


	void Start () {
		textMesh = gameObject.GetComponent<MeshRenderer>();	
	}

	// Update is called once per frame
	void Update () {
		if (Vector2.Distance (transform.position, player.position) < distance) {
			textMesh.enabled = true;
		} else {
			textMesh.enabled = false;
		}
	}
}
