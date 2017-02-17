using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[SerializeField]
	private GameObject[] enemyList;
	[SerializeField]
	private GameObject[] enemyBossList;
	private Vector2 min;
	private Vector2 max;
	void Start(){
		min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
	}
	public void SpawnEnemy(int level){
		
		GameObject gameObjectClone;
		switch(level){
			case 1:
				gameObjectClone = (GameObject)Instantiate(enemyList[0]);
				gameObjectClone.transform.position = new Vector2(Random.Range (min.x, max.x), max.y);
				break;
			case 2:
				gameObjectClone = (GameObject)Instantiate(enemyList[1]);
				gameObjectClone.transform.position = new Vector2(Random.Range (min.x, max.x), max.y);
				break;
		}
	}

	public void SpawnEnemyBoss(int level){
		switch(level){
			case 1:
				GameObject gameObjectClone = (GameObject)Instantiate(enemyBossList[0]);
				gameObjectClone.transform.position = new Vector2(0, max.y);
				break;
		}
	}
}
