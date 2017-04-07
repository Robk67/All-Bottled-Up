using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour {

	public void loadScene(int index){
		WorldData.instance.CurrentScene = index;
		SceneManager.LoadScene (index);
	}
}
