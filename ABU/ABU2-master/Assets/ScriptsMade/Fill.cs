using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Fill : MonoBehaviour {
	public Image red;
	public Image blue;
	public Image yellow;

	private float maxAmount = 1f;
	private float colorAmountRed= 0f;
	private float colorAmountBlue= 0f;
	private float colorAmountYellow= 0f;

	public GameObject player;

	// Update is called once per frame
	void Update () {
		colorAmountRed = player.GetComponent<PowerupStateHandler> ().m_RedBottleAmount;
		if (colorAmountRed != maxAmount && red != null) {
			if (colorAmountRed > 0) {
				red.fillAmount = colorAmountRed;
				colorAmountRed += colorAmountRed;
			}
		}
		colorAmountBlue = player.GetComponent<PowerupStateHandler> ().m_BlueBottleAmount;
		if (colorAmountBlue != maxAmount && blue != null) {
			if (colorAmountBlue > 0) {
				blue.fillAmount = colorAmountBlue;
				colorAmountBlue += colorAmountBlue;
			}
		}
		colorAmountYellow = player.GetComponent<PowerupStateHandler> ().m_YellowBottleAmount;
		if (colorAmountYellow != maxAmount && yellow != null) {
			if (colorAmountYellow > 0) {
				yellow.fillAmount = colorAmountYellow;
				colorAmountYellow += colorAmountYellow;
			}
		}

	}
}