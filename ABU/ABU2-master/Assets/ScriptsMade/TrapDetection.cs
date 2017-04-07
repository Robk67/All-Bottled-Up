using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrapDetection : MonoBehaviour {

    public Vector2 m_Offset;
    public Vector2 m_Dimensions;
	public GameObject[] ThingsToActivate;
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 1);
        Vector3 topRight = new Vector3(transform.position.x + m_Offset.x + m_Dimensions.x, transform.position.y + m_Offset.y, transform.position.z);
        Vector3 bottomRight = new Vector3(transform.position.x + m_Offset.x + m_Dimensions.x, transform.position.y + m_Offset.y - m_Dimensions.y, transform.position.z);
        Vector3 bottomLeft = new Vector3(transform.position.x + m_Offset.x, transform.position.y + m_Offset.y - m_Dimensions.y, transform.position.z);
        Vector3 topLeft = new Vector3(transform.position.x + m_Offset.x, transform.position.y + m_Offset.y, transform.position.z);
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);
    }

    void OnEnable()
    {
        List<Collider2D> tempList = new List<Collider2D>(Physics2D.OverlapAreaAll(new Vector3(transform.position.x + m_Offset.x, transform.position.y + m_Offset.y, transform.position.z), new Vector3(transform.position.x + m_Offset.x + m_Dimensions.x, transform.position.y + m_Offset.y - m_Dimensions.y, transform.position.z)));
        for(int i = 0, iMax = tempList.Count; i < iMax; i++)
        {
            if (tempList[i].CompareTag("YellowGuy"))
            {
                tempList[i].GetComponent<Runner>().Speed = 0;
				tempList [i].tag = "Untagged";
				for(int j =0, jMax = ThingsToActivate.Length; j < jMax; j++)
				{
					ThingsToActivate[j].SetActive(true);
				}
                return;
            }
        }
    }
}
