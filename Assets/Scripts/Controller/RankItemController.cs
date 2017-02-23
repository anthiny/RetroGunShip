using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankItemController : MonoBehaviour {
	public Image rankIcon;
	public Text nickName;
	public Text score;

	public void SettingRankItem(Sprite rankiconImage, string nickName, string score, Color color){
		rankIcon.sprite = rankiconImage;
		rankIcon.color = color;
		this.nickName.text = nickName;
		this.score.text = score;
	}
}
