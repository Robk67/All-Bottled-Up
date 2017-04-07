using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class turnOffCredits : MonoBehaviour {
	public Animator creditsA;
	public Canvas credits;
	public float time; 
	// Use this for initialization
	void Start () {
		creditsA = credits.GetComponent<Animator>();
		time = 0;
	}

	// Update is called once per frame
	void Update () {
		time = Time.deltaTime;
		if (time >= 50.0f) {
			creditsA.enabled = !creditsA.enabled;
			SceneManager.LoadScene (1);
		}
	}
}
