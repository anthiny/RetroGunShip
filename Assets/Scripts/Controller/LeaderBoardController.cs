using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardController : MonoBehaviour {
	public GameObject rankItem;
	[SerializeField]
	private Vector3 startPosition;
	public Sprite[] rankingIconList;
	public Color[] colorList;
	public Text noRankingInfo;
	public Text myRankingScore;
	void Start () {
		this.gameObject.SetActive(false);
	}

	public void SettingBoard(){
		int idx = 0;
		int colorIdx = 0;
		Vector3 clonePosition = startPosition;

		if(NetworkManager.instance.IsRankingDataNull()){
			Debug.Log("No Ranking Data!");
			return;
		}

		noRankingInfo.enabled = false;

		foreach(var data in NetworkManager.instance.GetRankingData()){
			GameObject rankItemParent = GameObject.Find("RankItems");
			GameObject rankItemClone = Instantiate(rankItem);
			
			rankItemClone.transform.position = clonePosition;
			rankItemClone.transform.SetParent(rankItemParent.transform, false);
			rankItemClone.GetComponent<RankItemController>().SettingRankItem
			(rankingIconList[idx], data.Key, data.Value, colorList[colorIdx]);
			
			clonePosition.y = clonePosition.y - 60f;
			idx = idx + 1;
			if (colorIdx < 3){
				colorIdx = colorIdx + 1;
			}
		}

		myRankingScore.text = NetworkManager.instance.getScore();
	}

	public void Exit(){
		GameObject rankItemParent = GameObject.Find("RankItems");
		int childCount = rankItemParent.transform.childCount;
		Debug.Log(childCount);
		for(int i = 0; i<childCount; i++){
			Destroy(rankItemParent.transform.GetChild(i).gameObject);
		}
		this.gameObject.SetActive(false);
	}
}
