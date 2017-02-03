using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float speed = 0.1f;
	public bool doubleSpeed = false;
	public int curHp = 5;
	private Animator animator;
	private bool isLeft;
	private bool isRight;
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		animator.SetBool("isLeft",isLeft);
		animator.SetBool("isRight",isRight);
		
		if (Input.touchCount > 0){
				Touch touch = Input.GetTouch(0);

				if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved){
					Vector3 target = Camera.main.ScreenToWorldPoint(touch.position);
					target.z = 0;
					if (!TouchCheck(target)){
						isLeft = false;
						isRight = false;
						gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
						return;
					}
					Vector2 direction = target - transform.position;
					direction.Normalize();
					if(target.x > transform.position.x){
						isLeft = true;
						isRight = false;
					}
					else if(target.x < transform.position.x){
						isLeft = false;
						isRight = true;
					}
					else{
						isLeft = false;
						isRight = false;
					}
					gameObject.GetComponent<Rigidbody2D>().velocity = direction * 4;
				}
				else if(touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended){
					gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
					isLeft = false;
					isRight = false;
				}
		}

		if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer){
			
			
		}
		else{
			DeskTop();
		}
	}

	void DeskTop(){
		if (Input.GetAxis ("Horizontal") < -0.1f){
			isLeft = true;
			isRight = false;
			transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, 0);
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			isRight = true;
			isLeft = false;
			transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, 0);
		}
		if(Input.GetAxis("Vertical") > 0.1f){
			if(Input.GetAxis ("Horizontal") < -0.1f){
				isLeft = true;
				isRight = false;
			}
			else if(Input.GetAxis ("Horizontal") > 0.1f){
				isLeft = false;
				isRight = true;
			}
			else{
				isLeft = false;
				isRight = false;
			}
			transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), 0);
		}
		if(Input.GetAxis("Vertical") < -0.1f){
			if(Input.GetAxis ("Horizontal") < -0.1f){
				isLeft = true;
				isRight = false;
			}
			else if(Input.GetAxis ("Horizontal") > 0.1f){
				isLeft = false;
				isRight = true;
			}
			else{
				isLeft = false;
				isRight = false;
			}
			transform.position = new Vector3(transform.position.x, transform.position.y - (speed * Time.deltaTime), 0);
		}
		if(Input.GetAxis("Vertical") == 0.0f && Input.GetAxis("Horizontal") == 0.0f) {
			isLeft = false;
			isRight = false;	
		}
	}

	bool TouchCheck(Vector3 target){
		if (Mathf.Abs(target.y - transform.position.y) > 0.3 || Mathf.Abs(target.x - transform.position.x) > 0.3){
			return true;
		}
		else{
			return false;
		}
	}
	public void Damage(int damage){
		animator.SetTrigger("Heat");
		SoundManager.instance.mainSwitch("damagedSound", true);
		curHp = curHp - damage;
		if(curHp <= 0){
			Die();
		}
	}
	void Die(){
		//Restart
		SoundManager.instance.mainSwitch("inGameBackGround", false);
		ScoreManager.instance.SaveBestScore();
		PopUpManager.instance.ShowResultPopUp();
	}

}
