using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour {
	void OnTriggerExit2D (Collider2D c)
	{
		//Get the items layer name
		string tagName = c.gameObject.tag;
		//If it is an enemy...
		if (tagName == "Bullet" || tagName == "Item" || tagName == "Enemy")
		{
			Destroy(c.gameObject);
		}
	}
}
