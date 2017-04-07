using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadCurrentScene : MonoBehaviour {

	public void loadCurrendLevel(){
		SceneManager.LoadScene (WorldData.instance.CurrentScene);
	}

}
