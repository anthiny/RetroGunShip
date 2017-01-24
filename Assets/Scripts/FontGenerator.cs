using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FontGenerator : MonoBehaviour {
	public Sprite[] fontSet;
	// Use this for initialization
	private static FontGenerator _instance = null;
	public static FontGenerator instance{
		get{
			if(!_instance){
				_instance = FindObjectOfType(typeof(FontGenerator)) as FontGenerator;
				if(!_instance){
					GameObject container = new GameObject();
					container.name = "FontGeneratorContainer";
					_instance = container.AddComponent(typeof(FontGenerator)) as FontGenerator;
				}
			}
			return _instance;
		}
	}

	public void makeFont(GameObject parentObjcet, string text, float spacing, bool isButtonText, float size){
		float defaultSpacing = 0;
		for(int i=0; i<text.Length;i++){
			GameObject customChar = new GameObject("char" + i.ToString());
			customChar.transform.parent = parentObjcet.transform;
			customChar.transform.position = new Vector3(parentObjcet.transform.position.x + defaultSpacing, parentObjcet.transform.position.y, parentObjcet.transform.position.z);
			defaultSpacing = defaultSpacing + spacing;
			int askiiCode = (int)text[i];
			askiiCode = askiiCode - 97;
			if (askiiCode == -65){
				askiiCode = 36;
			}
			if (isButtonText){
				customChar.AddComponent<LayoutElement>();
				customChar.AddComponent<Image>().sprite = fontSet[askiiCode];
				customChar.GetComponent<RectTransform>().sizeDelta = new Vector2(customChar.GetComponent<RectTransform>().rect.width*size, customChar.GetComponent<RectTransform>().rect.height*size);
			}
			else{
				customChar.AddComponent<SpriteRenderer>().sprite = fontSet[askiiCode];
				customChar.GetComponent<SpriteRenderer>().sortingLayerName = "UiPanel";
			}
		}
	}
}
