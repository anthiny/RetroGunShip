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
		if(Input.GetAxis("Vertical") == 0.0f && Input.GetAxis("Horizontal") == 0.0f){
			isLeft = false;
			isRight = false;	
		}
	}
	public void Damage(int damage){
		if(curHp <= 0){
			Die();
		}
		curHp = curHp - damage;
		animator.SetTrigger("Heat");
	}
	void Die(){
		//Restart
		SceneManager.LoadScene("InGame");
	}

}
