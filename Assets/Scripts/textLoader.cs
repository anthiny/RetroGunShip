using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textLoader : MonoBehaviour {
	public GameObject[] TextList;
	// Use this for initialization
	void Start () {
		foreach(GameObject TextItem in TextList){
			TextItem.GetComponentInChildren<FontInfo>().FontLoad();
		}
	}
}
