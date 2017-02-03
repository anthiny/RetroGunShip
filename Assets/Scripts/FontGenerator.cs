using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FontGenerator : MonoBehaviour {
	public Sprite[] fontSet;
	// Use this for initialization
	private static FontGenerator _instance = null;
	public Color[] colorList;
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

	public void makeFont(GameObject parentObjcet, string text, float spacing, bool onCanvas, float size, int colorIndex){
		float defaultSpacing = 0;
		for(int i=0; i<text.Length;i++){
			GameObject customChar = new GameObject("char" + i.ToString());
			customChar.transform.SetParent(parentObjcet.transform, false);
			customChar.transform.position = new Vector3(parentObjcet.transform.position.x + defaultSpacing, parentObjcet.transform.position.y, parentObjcet.transform.position.z);
			defaultSpacing = defaultSpacing + spacing;

			int askiiCode = (int)text[i];

			if (askiiCode == 32){
				askiiCode = 36;
			}
			else if(askiiCode > 96 && askiiCode < 123){
				askiiCode = askiiCode - 97;
			}
			else if(askiiCode > 47 && askiiCode < 58){
				askiiCode = askiiCode - 22;
			}
			
			if (onCanvas){
				customChar.AddComponent<LayoutElement>();
				customChar.AddComponent<Image>().sprite = fontSet[askiiCode];
				if(colorIndex != 0){
					customChar.GetComponent<Image>().color = colorList[colorIndex];
				}
				customChar.GetComponent<RectTransform>().sizeDelta = new Vector2(customChar.GetComponent<RectTransform>().rect.width*size, customChar.GetComponent<RectTransform>().rect.height*size);
			}
			else{
				customChar.AddComponent<SpriteRenderer>().sprite = fontSet[askiiCode];
				customChar.GetComponent<SpriteRenderer>().sortingLayerName = "UiPanel";
				customChar.GetComponent<SpriteRenderer>().sortingOrder = 1;
			}
		}
	}
}
