using UnityEngine;
using System.Collections;

public class PickUp : ActivatableScript {

	public Transform PlayerTransform;
	public Vector2 AttachOffset;

	[HideInInspector] public bool AttachedToPlayer = false;

	public override void RunActivatableScript()
	{
		AttachedToPlayer = true;
		transform.parent = PlayerTransform;
		transform.localPosition = new Vector3(AttachOffset.x, AttachOffset.y, 0);
	}
}