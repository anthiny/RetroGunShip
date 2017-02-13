using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodySet : MonoBehaviour {
	public int maxHp;
	[SerializeField]
	private int curHp; 
	public int score;
	public GameObject[] itemList;
	public GameObject[] effectList;
	public GameObject scorePre;
	[SerializeField]
	private AttackPatternParent attactPattern;
	[SerializeField]
	private MovePatternParent movePattern;
	void Start(){
		curHp = maxHp;
	}
	void Update(){
		attactPattern.Attack();
		movePattern.Move();
	}

	public void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("Player")){
			col.gameObject.GetComponent<Player>().Damage(1);
			Destroy(gameObject);
		}
	}

	public void Damage(int damage){
		SoundManager.instance.mainSwitch("damagedSound", true);
		curHp = curHp - damage;
		if(maxHp > 1){
			GameObject dummyEffect;
			dummyEffect = Instantiate(effectList[0], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
			dummyEffect.transform.parent = this.gameObject.transform;
		}
		if(curHp <= 0){
			Die();
		}
	}

	private void Die(){
		ScoreModel.instance.addScore(score);
		GameMasterController.instance.DisplayScoreText();
		GameObject.Instantiate(effectList[1], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
		if (itemList.Length > 0){
			DropItem();
		}
		ShowScore();
		Destroy(gameObject);
	}

	private void DropItem(){
		GameObject.Instantiate(itemList[Random.Range(0,itemList.Length)], transform.position, transform.rotation);
	}

	private void ShowScore(){
		GameObject.Instantiate(scorePre, transform.position, transform.rotation);
	}
}
