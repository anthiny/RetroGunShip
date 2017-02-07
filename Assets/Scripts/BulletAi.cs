using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAi : MonoBehaviour {
	public string targetTag;
	public int damage;
	public float h;
	public float w;
	public void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag(targetTag)){
			switch(targetTag){
				case "Player":
					col.gameObject.GetComponent<Player>().Damage(damage);
					break;
				case "Enemy":
					col.gameObject.GetComponent<EnemyAi>().Damage(damage);
					break;
			}
			Destroy(gameObject);
		}
	}
}
