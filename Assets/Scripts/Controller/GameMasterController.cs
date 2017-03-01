using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMasterController : MonoBehaviour {
	public float spawnInterval;
	public float spawnTimer;
	[SerializeField]
	private int bossScore = 1000;
	//[SerializeField]
	//private int stageNum = 1;
	[SerializeField]
	private Text scoreText;
	private static GameMasterController _instance = null;
	public static GameMasterController instance{
		get{
			if(!_instance){
				_instance = FindObjectOfType(typeof(GameMasterController)) as GameMasterController;
				if(!_instance){
					GameObject container = new GameObject();
					container.name = "GameMasterControllerContainer";
					_instance = container.AddComponent(typeof(GameMasterController)) as GameMasterController;
				}
			}
			return _instance;
		}
	}
	void Start(){
		SoundManager.instance.mainSwitch("inGameBackGround", true);
		Time.timeScale = 1;
	}
	void Update(){
		spawnTimer = spawnTimer + Time.deltaTime;
		if(spawnTimer >= spawnInterval){
			if(ScoreModel.instance.GetScore()>=bossScore){
				this.GetComponent<EnemySpawner>().SpawnEnemyBoss(1);
				bossScore = bossScore*3;
			}
			else{
				this.GetComponent<EnemySpawner>().SpawnEnemy(Random.Range(1,3));
			}
			spawnTimer = 0;
		}
	}

	public void DisplayScoreText(){
		scoreText.text = "Score " + ScoreModel.instance.GetScore().ToString();
	}

}
