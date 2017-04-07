using UnityEngine;
using System.Collections;

public class LazerScript : MonoBehaviour {

	public GameObject m_Player;
	public float m_MovementSpeed;
	public float m_Lifetime;
	public string[] m_TagsToDestroy;
	private bool m_IsFacingRight;
	private float m_Age = 0;

	void Start () {
		m_IsFacingRight = m_Player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().IsFacingRight();
	}

	void FixedUpdate()
	{
		Vector3 currentPos = transform.position;
		currentPos.x += m_MovementSpeed * Time.fixedDeltaTime * (m_IsFacingRight ? 1 : -1);
		transform.position = currentPos;
		m_Age += Time.fixedDeltaTime;
		if(m_Age >= m_Lifetime)
		{
			Destroy(gameObject);
		}
	}
	/**/
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Touching thing");
		/*
        foreach (string s in m_TagsToDestroy)
        {
            if (other.CompareTag(s))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                break;
            }
        }
        /**/
		if (other.CompareTag("Boss"))
		{
			other.GetComponent<BossguyScript>().TakeDamage();
			Destroy(gameObject);
		}
		if (other.CompareTag("BadGuy"))
		{
			
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
	/**/
}
