using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPattern01 : AttackPatternParent {
	override protected void Pattern(){
		GameObject bulletClone;
		bulletClone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
		bulletClone.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * -bulletSpeed;
	}
}
