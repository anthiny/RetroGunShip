using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPatternParent : MonoBehaviour {
	public float shootInterval;
	public float bulletSpeed = 1;
	public float bulletTimer;
	public Vector3 muzzle;
	public GameObject bullet;
	public GameObject bulletGameObjectParent;
	void Start(){
		bulletGameObjectParent = GameObject.Find("BulletPooling");
	}
	public void Attack(){
		bulletTimer = bulletTimer + Time.deltaTime;
		if(bulletTimer >= shootInterval){
			Pattern();
			bulletTimer = 0;
		}
	}

	 protected virtual void Pattern(){}
}
