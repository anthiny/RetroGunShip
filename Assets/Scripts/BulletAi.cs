using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAi : MonoBehaviour {
	public int damage;
	public float h;
	public float w;
	void Start(){
	}
	void Update(){
		if(transform.position.x > w || transform.position.y > h
		|| transform.position.x < - w || transform.position.y < -h){
			Destroy(gameObject);
		}
	}

	public void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("Player")){
			col.gameObject.GetComponent<Player>().Damage(damage);
			Destroy(gameObject);
		}
	}

}
