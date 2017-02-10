using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPatternParent : MonoBehaviour {
	public float shootInterval;
	public float bulletSpeed = 1;
	public float bulletTimer;
	public GameObject bullet;
	public void Attack(){
		bulletTimer = bulletTimer + Time.deltaTime;
		if(bulletTimer >= shootInterval){
			Pattern();
			bulletTimer = 0;
		}
	}

	 protected virtual void Pattern(){}
}
