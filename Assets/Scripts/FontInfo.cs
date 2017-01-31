using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontInfo : MonoBehaviour {
	public string text;
	public float spacing;
	public bool onTheCavas = false;
	public float fontSize = 1;
	// Use this for initialization

	public void FontLoad(){
		FontGenerator.instance.makeFont(this.gameObject, text.ToLower(),spacing, onTheCavas, fontSize);
	}
}
