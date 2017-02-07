using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float shootInterval;
	public float bulletSpeed = 100;
	public float bulletTimer;
	public float speed = 0.1f;
	public bool doubleSpeed = false;
	public int curHp = 5;
	public GameObject bullet;
	private Animator animator;
	private bool isLeft;
	private bool isRight;
	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		Shot();
		animator.SetBool("isLeft",isLeft);
		animator.SetBool("isRight",isRight);

		float x = Input.GetAxisRaw ("Horizontal");
		float y = Input.GetAxisRaw ("Vertical");
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		Vector2 pos = transform.position;
		Vector2 direction;

		if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer){
				if (Input.touchCount > 0)
				{
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

						direction = target - transform.position;
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

						pos += direction  * speed * Time.deltaTime;
						pos.x = Mathf.Clamp (pos.x, min.x, max.x);
						pos.y = Mathf.Clamp (pos.y, min.y, max.y);
						transform.position = pos;
					}
					else if(touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended){
						gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);
						isLeft = false;
						isRight = false;
					}
			}
		}
		else{
			direction = new Vector2 (x, y).normalized;
			Move (direction, min, max);
		}
	}

	void Move(Vector2 direction, Vector2 min, Vector2 max){
		Vector2 pos = transform.position;
		pos += direction  * speed * Time.deltaTime;
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		if (Input.GetAxis ("Horizontal") < -0.1f){
			isLeft = true;
			isRight = false;
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			isRight = true;
			isLeft = false;
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
		}
		if(Input.GetAxis("Vertical") == 0.0f && Input.GetAxis("Horizontal") == 0.0f) {
			isLeft = false;
			isRight = false;	
		}
		transform.position = pos;
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

	public void Shot()
	{	
		bulletTimer = bulletTimer + Time.deltaTime;
		
		if(bulletTimer >= shootInterval){
			GameObject bulletClone;
			bulletClone = Instantiate(bullet, new Vector3(transform.position.x + 0.03f, transform.position.y + 0.06f, transform.position.z), transform.rotation) as GameObject;
			bulletClone.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * 6;
			bulletTimer = 0;
		}
	}

}
