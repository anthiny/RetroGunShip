using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	private float score;
	//private int objectCnt;
	public GameObject[] gameObjectList;
	public float[] xPointList;
	void Start(){
		//SoundManager.instance.mainSwitch("inGameBackGround", true);
		Time.timeScale = 1;
		score = 0;
	} 
	void Update(){
		score = score + (Time.deltaTime * 1);
		DisplayScore((int)score);
	}

	public void DisplayScore(int score){
		ScoreManager.instance.SetScore(score);
	}

	private void LoadingObject(string objectName){
		switch(objectName){
			case "meteroite":
				for(int i = 0; i<3; i++){
					GameObject gameObjectClone;
					gameObjectClone = Instantiate(gameObjectList[0], new Vector3(xPointList[i], Random.Range(8.5f,12f), 0), Quaternion.identity) as GameObject;
					Vector2 direction = new Vector3(0f,-2.5f,0f) - transform.position;
					direction.x = 0;
					gameObjectClone.GetComponent<Rigidbody2D>().velocity = direction;
				}
				break;
		}
	}
}
