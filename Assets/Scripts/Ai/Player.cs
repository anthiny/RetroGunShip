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
	[SerializeField]
	private bool doubleMissile = false;
	[SerializeField]
	private bool onShield = false;
	public GameObject shieldEffect;
	public int curHp = 5;
	public GameObject bullet;
	public GameObject bulletGameObjectParent;
	private Animator animator;
	private bool isLeft;
	private bool isRight;
	// Use this for initialization
	void Start () {
		bulletGameObjectParent = GameObject.Find("BulletPooling");
		shieldEffect.SetActive(false);
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
						target.y = target.y + 0.6f;
						target.z = 0;

						direction = target - transform.position;
						var distance = direction.magnitude;
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

						pos = pos + direction * Mathf.Min(distance, speed * Time.deltaTime);
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

	public void Damage(int damage){
		animator.SetTrigger("Heat");
		SoundManager.instance.mainSwitch("damagedSound", true);
		if(onShield){
			ShieldSwitch(false);
		}
		else{
			curHp = curHp - damage;
			if(curHp <= 0){
				Die();
			}
		}
	}
	void Die(){
		//Restart
		SoundManager.instance.mainSwitch("inGameBackGround", false);
		//ScoreModel.instance.SaveBestScore();
		PopUpManager.instance.ShowResultPopUp();
	}

	private void Shot()
	{	
		bulletTimer = bulletTimer + Time.deltaTime;
		
		if(bulletTimer >= shootInterval){
			MakeMissile();
			bulletTimer = 0;
		}
	}

	private void MakeMissile(){
		if (doubleMissile){
			GameObject leftBulletClone, rightBulletClone;
			
			leftBulletClone = Instantiate(bullet, new Vector3(transform.position.x - 0.23f, transform.position.y + 0.06f, transform.position.z), transform.rotation) as GameObject;
			leftBulletClone.transform.SetParent(bulletGameObjectParent.transform, false);
			leftBulletClone.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * bulletSpeed;

			rightBulletClone = Instantiate(bullet, new Vector3(transform.position.x + 0.25f, transform.position.y + 0.06f, transform.position.z), transform.rotation) as GameObject;
			rightBulletClone.transform.SetParent(bulletGameObjectParent.transform, false);
			rightBulletClone.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * bulletSpeed;

		}
		else{
			GameObject bulletClone;
			bulletClone = Instantiate(bullet, new Vector3(transform.position.x + 0.03f, transform.position.y + 0.06f, transform.position.z), transform.rotation) as GameObject;
			bulletClone.transform.SetParent(bulletGameObjectParent.transform, false);
			bulletClone.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * bulletSpeed;
		}
	}
	public void MissileUpgrade(){
		if(doubleMissile){
			ScoreModel.instance.addScore(50);
			return;
		}
		doubleMissile = true;
	}
	public void ShieldSwitch(bool value){
		if(onShield == true && value == true){
			ScoreModel.instance.addScore(50);
			return;
		}
		onShield = value;
		shieldEffect.SetActive(onShield);
	}
	
}