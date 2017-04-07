using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

    public float Speed;

    private bool isFacingLeft;

	void Start () {
        isFacingLeft = true;
	}
	
	void Update () {
        Vector3 currentPos = transform.position;
        currentPos.x += Speed * Time.deltaTime * (isFacingLeft ? -1 : 1);
        transform.position = currentPos;
	}

    public void Flip()
    {
        isFacingLeft = !isFacingLeft;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }
}
