using UnityEngine;
using System.Collections;

public class PowerupStateHandler : MonoBehaviour {
    public enum BottleColors { Red, Yellow, Blue };

	[Range(0,1)] public float m_BlueBottleAmount;
	[Range(0,1)] public float m_RedBottleAmount;
	[Range(0,1)]public float m_YellowBottleAmount;
	 
    public float m_RedLazerCooldown;
	[Range(0, 1)] public float m_RedLazerCost;
	public float m_YellowDrainSpeed;
	public float m_BlueDrainSpeed;

    private bool m_BlueIsActive;
    private bool m_YellowIsActive;
    private float m_currentRedCooldown;

	public GameObject m_Lazer;
	public float m_YellowBoostAmount;

	public bool YellowIsActive
	{
		get
		{
			return m_YellowIsActive;
		}
	}
	// Use this for initialization
	void Start () {
       // m_BlueBottleAmount = 0;
       // m_RedBottleAmount = 0;
       // m_YellowBottleAmount = 0;

        m_BlueIsActive = false;
        m_YellowIsActive = false;
        m_currentRedCooldown = 0;
	}

	void Update()
	{
		if(m_YellowIsActive)
		{
			m_YellowBottleAmount -= m_YellowDrainSpeed * Time.deltaTime;
			if(m_YellowBottleAmount <= 0)
			{
				m_YellowBottleAmount = 0;
				ToggleColor (BottleColors.Yellow);
			}
		}
		else if(m_BlueIsActive)
		{
			m_BlueBottleAmount -= m_BlueDrainSpeed * Time.deltaTime;
			if(m_BlueBottleAmount <= 0)
			{
				m_BlueBottleAmount = 0;
				ToggleColor (BottleColors.Blue);
			}
		}
		if(m_currentRedCooldown > 0)
		{
			m_currentRedCooldown -= Time.deltaTime;
			if(m_currentRedCooldown < 0)
			{
				m_currentRedCooldown = 0;
			}
		}
	}

	public void IncrementBlue(float value)
	{
		m_BlueBottleAmount += value;
		if(m_BlueBottleAmount > 1)
		{
			m_BlueBottleAmount = 1;
		}
	}

	public void IncrementRed(float value)
	{
		m_RedBottleAmount += value;
		if(m_RedBottleAmount > 1)
		{
			m_RedBottleAmount = 1;
		}
	}

	public void IncrementYellow(float value)
	{
		m_YellowBottleAmount += value;
		if(m_YellowBottleAmount > 1)
		{
			m_YellowBottleAmount = 1;
		}
	}

	public void ToggleColor(BottleColors color)
	{
		if(color == BottleColors.Red)
		{
			if(m_RedBottleAmount > 0f && m_currentRedCooldown == 0f && !ColorIsActive())
			{
				FireLazer();
				m_RedBottleAmount -= m_RedLazerCost;
				if(m_RedBottleAmount < 0)
				{
					m_RedBottleAmount = 0;
				}
				m_currentRedCooldown = m_RedLazerCooldown;
			}
		}
		else if(color == BottleColors.Yellow)
		{
			if(!m_YellowIsActive && m_YellowBottleAmount > 0 && !ColorIsActive())
			{
				Debug.Log ("Yellow on");
				m_YellowIsActive = true;
				GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_MaxSpeed += m_YellowBoostAmount;
			}
			else
			{
				Debug.Log ("Yellow off");
				if (m_YellowIsActive)
				{
					GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_MaxSpeed -= m_YellowBoostAmount;
				}
				m_YellowIsActive = false;
			}
		}
		else if(color == BottleColors.Blue)
		{
			if(!m_BlueIsActive && m_BlueBottleAmount > 0 && !ColorIsActive())
			{
				m_BlueIsActive = true;
				GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_DamageAmount = 0;
				transform.Find("Shield").gameObject.SetActive(true);
			}
			else
			{
				if (m_BlueIsActive)
				{
					GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_DamageAmount = 1;
					transform.Find("Shield").gameObject.SetActive(false);
				}
				m_BlueIsActive = false;
			}
		}
	}

	public bool ColorIsActive()
	{
		return m_BlueIsActive || m_YellowIsActive;
	}

	void FireLazer()
	{
		GameObject newLazer = Instantiate (m_Lazer) as GameObject;
		newLazer.transform.position = GetComponent<OverlapDetection> ().transform.position;
		newLazer.SetActive (true);
	}

}
