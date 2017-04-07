using UnityEngine;
using System.Collections;

namespace ABU
{
    public class Spikes : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_Player;
        private BoxCollider2D m_MyCollider;
        private CircleCollider2D m_PlayerCollider;

        void Start()
        {
			m_MyCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
            m_PlayerCollider = m_Player.GetComponent<CircleCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Physics2D.IsTouching(m_MyCollider, m_PlayerCollider))
            {
                m_Player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().TakeDamage();
            }
        }
    }
}
