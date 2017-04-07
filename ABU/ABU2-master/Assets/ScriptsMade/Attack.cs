using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public float m_Speed;
    public float m_Lifetime;

    private float m_Age = 0;

	void Update () {
        m_Age += Time.deltaTime;
        Vector3 myPosition = transform.position;
        myPosition.x -= m_Speed * Time.deltaTime;
        transform.position = myPosition;

        if(m_Age >= m_Lifetime)
        {
            Destroy(gameObject);
        }
	}
}
