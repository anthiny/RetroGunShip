using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	private float lastUpdate;
	private int score;
	private int objectCnt;
	public Text pointsText;
	public GameObject[] gameObjectList;
	public float[] xPointList;
	void Start(){
		score = 0;
		objectCnt = 0;
	} 
	void Update(){
		if(Time.time - lastUpdate >= 1f){
			lastUpdate = Time.time;
			score = score + 1;
			objectCnt = objectCnt + 1;

			if (objectCnt == 3){
				//LoadingObject("meteroite");
				objectCnt = 0;
			}

			DisplayScore(score);
		}
	}

	public void DisplayScore(int score){
		ScoreManager.instance.SetScore(score);
		pointsText.text = ("Score: " + score);
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
