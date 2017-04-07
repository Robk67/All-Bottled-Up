using UnityEngine;
using System.Collections;

public class LazerForRedGuy : MonoBehaviour {

	public GameObject m_Player;
	public float m_MovementSpeed;
	public float m_Lifetime;
	public string[] m_TagsToDestroy;
	public GameObject player;
	private bool m_IsFacingLeft;
	private float m_Age = 0;
	private Vector3 playersPosition;
	public GameObject bWall;

	void Start () {
		m_IsFacingLeft = false;
	}
	void Update(){
		

			playersPosition = player.transform.position;

			if (playersPosition.x < m_Player.transform.position.x) {
				m_IsFacingLeft = false;

			} 
		else if (playersPosition.x == m_Player.transform.position.x) {
			Destroy (gameObject);
			m_IsFacingLeft = true;

		} 
		else if (playersPosition.x > m_Player.transform.position.x) {
				m_IsFacingLeft = true;

			} 

		} 



	void FixedUpdate()
	{
		Vector3 currentPos = transform.position;
		currentPos.x += m_MovementSpeed * Time.fixedDeltaTime * (m_IsFacingLeft ? 1 : -1);
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
		if (other.CompareTag("Wall")){
			Destroy(gameObject);
		}
		if (other.CompareTag ("BreakableWall")) {
			Destroy (gameObject);
			bWall.GetComponent<BreakWall>().goAway ();
			bWall.SetActive (false);

		}
	}
	/**/
}
