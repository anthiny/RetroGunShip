using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPattern01 : AttackPatternParent {

	override protected void Pattern(){
		GameObject bulletClone;
		bulletClone = Instantiate(bullet, transform.position + muzzle, transform.rotation) as GameObject;
		bulletClone.transform.SetParent(bulletGameObjectParent.transform, false);
		bulletClone.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * -bulletSpeed;
	}
}
