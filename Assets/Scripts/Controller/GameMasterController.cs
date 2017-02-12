using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMasterController : MonoBehaviour {
	public float spawnInterval;
	public float spawnTimer;
	public int bossScore = 1000;
	void Start(){
		SoundManager.instance.mainSwitch("inGameBackGround", true);
		Time.timeScale = 1;
	}
	void Update(){
		spawnTimer = spawnTimer + Time.deltaTime;
		if(spawnTimer >= spawnInterval){
			if(ScoreController.instance.GetScore()>=bossScore){
				this.GetComponent<EnemySpawner>().SpawnEnemyBoss(1);
				bossScore = bossScore*3;
			}
			else{
				this.GetComponent<EnemySpawner>().SpawnEnemy(1);
			}
			spawnTimer = 0;
		}
	}

}
