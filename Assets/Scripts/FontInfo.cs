using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontInfo : MonoBehaviour {
	public string text;
	public float spacing;
	public bool isButtonText = false;
	public float fontSize = 1;
	// Use this for initialization
	void Start () {
		FontGenerator.instance.makeFont(this.gameObject, text.ToLower(),spacing, isButtonText, fontSize);
	}
}
