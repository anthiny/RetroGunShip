using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPatternBoss02 : AttackPatternParent {

	override protected void Pattern(){
		GameObject leftBulletClone;
		leftBulletClone = Instantiate(bullet, transform.position + muzzle, transform.rotation) as GameObject;
		leftBulletClone.transform.SetParent(bulletGameObjectParent.transform, false);
		leftBulletClone.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * -bulletSpeed + transform.right.normalized * -bulletSpeed;

		GameObject centerBulletClone;
		centerBulletClone = Instantiate(bullet, transform.position + muzzle, transform.rotation) as GameObject;
		centerBulletClone.transform.SetParent(bulletGameObjectParent.transform, false);
		centerBulletClone.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * -bulletSpeed;

		GameObject rightBulletClone;
		rightBulletClone = Instantiate(bullet, transform.position + muzzle, transform.rotation) as GameObject;
		rightBulletClone.transform.SetParent(bulletGameObjectParent.transform, false);
		rightBulletClone.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * -bulletSpeed + transform.right.normalized * bulletSpeed;
	}
}
