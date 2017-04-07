using UnityEngine;
using System.Collections;

public class LazerDestroyer : MonoBehaviour {

    public GameObject m_Player;

    private CircleCollider2D m_BubbleCollider;

	void Start () {
        m_BubbleCollider = GetComponent<CircleCollider2D>();
	}
	
	void FixedUpdate () {
        Collider2D[] overlaps = Physics2D.OverlapCircleAll(m_BubbleCollider.transform.position, m_BubbleCollider.radius * transform.localScale.y, LayerMask.GetMask(new string[] { "Lazer" }));
        foreach(Collider2D collider in overlaps)
        {
            Destroy(collider.gameObject);
        }
	}
}
