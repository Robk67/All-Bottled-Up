using UnityEngine;
using System.Collections;

public class ZoomDetection : MonoBehaviour {

    public GameObject m_Player;
    public GameObject m_Shield;

    private CircleCollider2D m_BubbleCollider;
    private BoxCollider2D m_PlayerCollider;

	// Use this for initialization
	void Start () {
        m_BubbleCollider = GetComponent<CircleCollider2D>();
        m_PlayerCollider = m_Player.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics2D.IsTouching(m_BubbleCollider, m_PlayerCollider))
        {
            if (m_Player.GetComponent<PowerupStateHandler>().YellowIsActive)
            {
                m_Shield.gameObject.SetActive(false);
                return;
            }
        }
    }
}
