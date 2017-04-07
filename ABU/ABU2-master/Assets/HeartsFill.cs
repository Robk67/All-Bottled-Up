using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeartsFill : MonoBehaviour {
	public Image heart1;
	public Image heart2;
	public Image heart3;
	private float currentHealth;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		currentHealth= player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D> ().m_CurrentHealth;
		if (currentHealth == 3f ) {
			heart1.fillAmount = 1.0f;
			heart2.fillAmount = 1.0f;
			heart3.fillAmount = 1.0f;
		}
		if (currentHealth == 2f ) {
			heart1.fillAmount = 1.0f;
			heart2.fillAmount = 1.0f;
			heart3.fillAmount = 0f;
		}
		if (currentHealth == 1f  ) {
			heart1.fillAmount = 1.0f;
			heart2.fillAmount = 0f;
			heart3.fillAmount = 0f;
		}
		if (currentHealth == 0f  ) {
			heart1.fillAmount = 0f;
			heart2.fillAmount = 0f;
			heart3.fillAmount = 0f;
		}
	}
}
