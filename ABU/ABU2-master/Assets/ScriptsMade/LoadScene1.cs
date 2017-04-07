using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene1 : MonoBehaviour {
	
	public void loadByIndex(int index){
		SceneManager.LoadScene (index);
	}
}
