using UnityEngine;
using System.Collections;
using System;

public class GiveFlower : ActivatableScript {

	public GameObject flower;

	public GameObject[] ThingsToActivate;

	public Vector2 FlowerPlacement;

	public override void RunActivatableScript()
	{
		if (flower.GetComponent<PickUp>().AttachedToPlayer)
		{
			flower.GetComponent<PickUp>().AttachedToPlayer = false;
			flower.transform.parent = null;
			flower.transform.position = new Vector3(FlowerPlacement.x, FlowerPlacement.y, flower.transform.position.z);

			for(int i = 0, iMax = ThingsToActivate.Length; i < iMax; i++)
			{
				ThingsToActivate[i].SetActive(true);
			}
		}
	}
}