using UnityEngine;
using System.Collections;

public class WorldData : MonoBehaviour {

	public int CurrentScene;

	public static WorldData instance;

	void Awake(){
		if (instance == null) {
			Object.DontDestroyOnLoad (gameObject);
			instance = this;
		}
	}
}
