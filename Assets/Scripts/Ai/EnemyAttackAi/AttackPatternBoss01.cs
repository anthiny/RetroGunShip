using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPatternBoss01 : AttackPatternParent {
	public GameObject target;
	void Start(){
		target = GameObject.FindGameObjectWithTag("Player");
	}
	override protected void Pattern(){
		Vector2 direction = target.transform.position - transform.position;
		direction.Normalize();

		GameObject bulletClone;
		bulletClone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
		bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
	}
}
