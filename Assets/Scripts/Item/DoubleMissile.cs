using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleMissile : MonoBehaviour {
	void OnTriggerEnter2D (Collider2D c)
	{
		//Get the items layer name
		string tagName = c.gameObject.tag;
		if (tagName == "Player")
		{
			c.gameObject.GetComponent<Player>().doubleMissile = true;
			Destroy(this.gameObject);
		}
	} 
}
