using UnityEngine;
using System.Collections;

public class BottleScript : MonoBehaviour {

    public PowerupStateHandler.BottleColors m_BottleColor;
    [Range(0, 1)]
    public float m_RefillAmount;
    public bool DestroyOnActivation;

    public void RefillPlayer(GameObject player)
    {
        if(m_BottleColor == PowerupStateHandler.BottleColors.Red)
        {
            player.GetComponent<PowerupStateHandler>().IncrementRed(m_RefillAmount);
        }
        else if(m_BottleColor == PowerupStateHandler.BottleColors.Blue)
        {
            player.GetComponent<PowerupStateHandler>().IncrementBlue(m_RefillAmount);
        }
        else if(m_BottleColor == PowerupStateHandler.BottleColors.Yellow)
        {
            player.GetComponent<PowerupStateHandler>().IncrementYellow(m_RefillAmount);
        }

        if (DestroyOnActivation)
        {
            gameObject.SetActive(false);
        }
    }

}
