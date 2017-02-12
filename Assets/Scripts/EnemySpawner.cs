using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[SerializeField]
	private GameObject[] enemyList;
	[SerializeField]
	private GameObject[] enemyBossList;

	public void SpawnEnemy(int level){
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		switch(level){
			case 1:
				GameObject gameObjectClone = (GameObject)Instantiate(enemyList[0]);
				gameObjectClone.transform.position = new Vector2(Random.Range (min.x, max.x), max.y);
				break;
		}
	}

	public void SpawnEnemyBoss(int level){
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		switch(level){
			case 1:
				GameObject gameObjectClone = (GameObject)Instantiate(enemyBossList[0]);
				gameObjectClone.transform.position = new Vector2(0, max.y);
				break;
		}
	}
}
