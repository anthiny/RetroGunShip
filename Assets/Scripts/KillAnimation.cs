using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAnimation : MonoBehaviour {
	public float animationLength;
	void Start(){
		StartCoroutine(KillOnAnimationEnd());
	}

	private IEnumerator KillOnAnimationEnd(){
		 yield return new WaitForSeconds (animationLength);
         Destroy (this.gameObject);
	}
}
