using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePattern01 : MovePatternParent {
	override public void Move(){
		gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * movementSpeed;
	}
}
