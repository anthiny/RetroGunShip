using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour {
	public float shootInterval;
	public float bulletSpeed = 100;
	public float bulletTimer;

	public GameObject bullet;
	public GameObject[] effectList;
	public int curHp; 
	public void Update(){
		Attack();
		//Move();
	}
	public void Attack(){
		bulletTimer = bulletTimer + Time.deltaTime;
		
		if(bulletTimer >= shootInterval){
			GameObject bulletClone;
			bulletClone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
			bulletClone.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * -8;
			bulletTimer = 0;
		}
	}
	public void Move(){
		
	}
	
}
