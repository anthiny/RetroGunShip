using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontInfo : MonoBehaviour {
	public string text;
	public float spacing;
	public bool onTheCavas = false;
	public float fontSize = 1;
	public int colorIndex = 0;
	public string[] color = {"default", "black", "white", "red"};	
	// Use this for initialization

	public void FontLoad(){
		FontManager.instance.makeFont(this.gameObject, text.ToLower(),spacing, onTheCavas, fontSize, colorIndex);
	}
}
