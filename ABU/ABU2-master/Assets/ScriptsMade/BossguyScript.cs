using UnityEngine;
using System.Collections;

public class BossguyScript : MonoBehaviour {

    private enum BossState { Idle, Attack };
    private BossState m_CurrentState;

    public GameObject m_AttackWaveObject;

    public float m_TimeBetweenAttacks; // How long the boss should be in the Idle state.
    public float m_AttackSpeed; // How long the boss should be in the Attack state.
    public float m_StateTransitionSpeed; // How long the boss should take to move up or down in state transitions.
    public float m_IdleYPosition;
    public float m_AttackYPosition;
    public float m_BobbingMultiplier = 1;
    public float m_BobbingHeight = 1;
    public int m_TotalHealth = 3;
    public GameObject m_Shield;
	public GameObject wall;
    private float m_StateTimer; // How long the boss has been in his current state.
    private float m_BossAge; // How long the boss has been alive, used for the bobbing idle animation.
    private float m_TransitionTime;

	void Start () {
        m_CurrentState = BossState.Idle;
        m_StateTimer = m_TimeBetweenAttacks;
        m_BossAge = 0;
	}
	
	void Update ()
    {
        m_BossAge += Time.deltaTime;
        UpdateState();
        CalculateYOffset();

	}

    void UpdateState()
    {
        m_StateTimer -= Time.deltaTime;
        if(m_StateTimer <= 0)
        {
            if(m_CurrentState == BossState.Idle)
            {
                m_CurrentState = BossState.Attack;
                m_StateTimer = m_AttackSpeed;
                m_TransitionTime = 0;
                LaunchAttack();
            }
            else if(m_CurrentState == BossState.Attack)
            {
                m_CurrentState = BossState.Idle;
                m_StateTimer = m_TimeBetweenAttacks;
                m_TransitionTime = 0;
            }
        }
    }

    void CalculateYOffset()
    {
        m_TransitionTime += Time.deltaTime;
        Vector2 myPosition = transform.position;
        if(m_CurrentState == BossState.Idle)
        {
            myPosition.y = ValueTweener(m_AttackYPosition, m_IdleYPosition, m_StateTransitionSpeed, m_TransitionTime);
        }
        else if(m_CurrentState == BossState.Attack)
        {
            myPosition.y = ValueTweener(m_IdleYPosition, m_AttackYPosition, m_StateTransitionSpeed, m_TransitionTime);
        }
        myPosition.y += Mathf.Cos(m_BossAge * m_BobbingMultiplier) * m_BobbingHeight;

        transform.position = myPosition;
    }

    public void TakeDamage()
    {
        m_TotalHealth--;
        if (m_TotalHealth == 0)
        {
            gameObject.SetActive(false);
			wall.SetActive (false);
            return;
        }

        m_Shield.SetActive(true);
    }

    void LaunchAttack()
    {
        GameObject BossAttack = Instantiate(m_AttackWaveObject) as GameObject;
        BossAttack.SetActive(true);
    }

    float ValueTweener(float start, float end, float duration, float xValue)
    {
        if(xValue >= duration)
        {
            return end;
        }
        return ((Mathf.Cos(Mathf.PI * xValue / duration) * (start - end)) + start + end) / 2.0f;
    }
}
