using UnityEngine;
using System.Collections;


[RequireComponent(typeof(SpriteRenderer))]
public class TileSprite : MonoBehaviour {

    private SpriteRenderer m_sprite;
    private Transform m_transform;
    
    void Awake()
    {
        m_sprite = GetComponent<SpriteRenderer>();
        m_transform = GetComponent<Transform>();

        m_sprite.enabled = false;
        GameObject childPrefab = new GameObject();
        SpriteRenderer childSprite = childPrefab.AddComponent<SpriteRenderer>();
        Vector3 tempScale = m_transform.localScale;
        tempScale.x = tempScale.y;
        tempScale.x /= m_transform.localScale.x;
        tempScale.y /= m_transform.localScale.y;
        childPrefab.transform.localScale = tempScale;
        /**/
        Vector3 tempPos = m_transform.position;
        tempPos.x -= ((m_sprite.sprite.bounds.size.x * m_transform.localScale.x) - (tempScale.x * (m_transform.localScale.x * m_sprite.sprite.bounds.size.x))) / 2.0f;
        childPrefab.transform.position = tempPos;
        childSprite.sprite = m_sprite.sprite;

        float tileWidth = m_sprite.sprite.bounds.size.x * m_transform.localScale.y;

        Vector3 correctScale = childPrefab.transform.localScale;

        GameObject child;
        for(int i = 1, iMax = Mathf.FloorToInt(m_transform.localScale.x / m_transform.localScale.y); i < iMax; i++)
        {
            
            child = Instantiate(childPrefab) as GameObject;
            Vector3 childPos = child.transform.position;
            childPos.x += tileWidth * i;
            child.transform.position = childPos;
            child.transform.parent = m_transform;
            child.transform.localScale = correctScale;
        }
        /**/
        childPrefab.transform.parent = m_transform;
        childPrefab.transform.localScale = correctScale;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
