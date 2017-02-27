using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class NetworkManager : MonoBehaviour {
	private string Id = "";
	private string nickName = "";
	private string score = "-";
	private Dictionary<string, string> rankingData = new Dictionary<string, string>();
	private static NetworkManager _instance = null;
	public static NetworkManager instance{
		get{
			if(!_instance){
				_instance = FindObjectOfType<NetworkManager>() as NetworkManager;
				if(!_instance){
					GameObject container = new GameObject();
					container.name = "NetworkManagerContainer";
					_instance = container.AddComponent(typeof(NetworkManager)) as NetworkManager;
				}
			}
			return _instance;
		}
	}

	void Awake(){
		PlayFabSettings.TitleId = "FD09";
	}
	
	public string getId(){
		return Id;
	}

	public string getScore(){
		return score;
	}

	public string getNickName(){
		return nickName;
	}

	public Dictionary<string, string> GetRankingData()
	{
		return rankingData;
	}
	public bool IsRankingDataNull(){
		if(rankingData.Count == 0){
			return true;
		}
		else{
			return false;
		}
	}
	public void Login(Action onSuccess, Action onFailure){
		if(PlayFabClientAPI.IsClientLoggedIn())
		{
			if(onSuccess != null)
				onSuccess.Invoke();
			return;
		}

		Debug.Log("Try to NetworkManager.Login");
		GetPlayerCombinedInfoRequestParams parameters = new GetPlayerCombinedInfoRequestParams(){
			GetUserAccountInfo = true
		};

		LoginWithAndroidDeviceIDRequest request = new LoginWithAndroidDeviceIDRequest(){
			TitleId = PlayFabSettings.TitleId,
			CreateAccount = true,
			
			AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
			AndroidDevice = SystemInfo.deviceModel,
			OS = SystemInfo.operatingSystem,
			InfoRequestParameters = parameters
			
		};

		PlayFabClientAPI.LoginWithAndroidDeviceID(request, 
			(result) => {OnLogin(onSuccess, onFailure, result);},
			(error) => {OnFailedLogin(onFailure, error);}
		);
	}

	private void OnLogin(Action onSuccess, Action onFailure, LoginResult result)
	{
		Debug.Log("NetworkManager.OnLogin");
		Debug.Log("   >>>>>> id: " + result.PlayFabId);
		Debug.Log("   >>>>>> DisplayName " + result.InfoResultPayload.AccountInfo.TitleInfo.DisplayName);
		Id = result.PlayFabId;
		nickName = result.InfoResultPayload.AccountInfo.TitleInfo.DisplayName;
		onSuccess();
	}

	private void OnFailedLogin(Action onFailure, PlayFabError error)
	{
		Debug.Log(error.ErrorMessage);
		if(onFailure != null)
			onFailure.Invoke();
		onFailure();
	}

	public void UploadScore(Action onSuccess, Action onFailure, int score){
		Debug.Log("Try to UpLoading Score");
		
		List<StatisticUpdate> userStatistics = new List<StatisticUpdate>();
		StatisticUpdate scoreInfo = new StatisticUpdate(){
			StatisticName = "HighScore",
			Version = null,
			Value = score,
		};

		userStatistics.Add(scoreInfo);
		UpdatePlayerStatisticsRequest request = new UpdatePlayerStatisticsRequest(){
			Statistics = userStatistics
		};

		PlayFabClientAPI.UpdatePlayerStatistics(request, 
			(result) => {UploadSuccess(onSuccess, result);},
			(error) => {UploadFail(onFailure, error);}
		);
	}

	private void UploadSuccess(Action onSuccess, UpdatePlayerStatisticsResult updatePlayerStatisticsResult){
		Debug.Log("Uploading Success");
		onSuccess();
	}

	private void UploadFail(Action onFailure, PlayFabError error){
		Debug.Log(error);
	}

	public void GetLeaderBoardData(Action onSuccess, Action onFailure){
		Debug.Log("Try to get LeaderBoard Data");

		GetLeaderboardRequest request = new GetLeaderboardRequest(){
			StatisticName = "HighScore",
			StartPosition = 0,
			MaxResultsCount = 5
		};

		PlayFabClientAPI.GetLeaderboard(request, 
			(result) => {GetLeaderboardSuccess(onSuccess, result);},
			(error) => {GetLeaderboardFail(onFailure, error);}
		);
	}

	private void GetLeaderboardSuccess(Action onSuccess, GetLeaderboardResult result){
		Debug.Log("GetLeaderboard data Success");
		rankingData.Clear();
		foreach(var data in result.Leaderboard){
			Debug.Log(data.DisplayName+ "/" + data.StatValue);
			if(data.PlayFabId == Id){
				score = data.StatValue.ToString();
			}
			rankingData.Add(data.DisplayName, data.StatValue.ToString());
		}
		onSuccess();
	}

	private void GetLeaderboardFail(Action onFailure, PlayFabError error){
		Debug.Log(error);
		onFailure();
	}

	public void UpdateNickName(Action onSuccess, Action onFailure, string nickName){
		Debug.Log("Update Nick Name");
		UpdateUserTitleDisplayNameRequest request = new UpdateUserTitleDisplayNameRequest(){
			DisplayName = nickName
		};

		PlayFabClientAPI.UpdateUserTitleDisplayName(request, 
			(result) => {UpdateNickNameSuccess(onSuccess, result);},
			(error) => {UpdateNickNameFailure(onFailure, error);}
		);
			
	}

	private void UpdateNickNameSuccess(Action onSuccess, UpdateUserTitleDisplayNameResult result){
		Debug.Log("UpdateNickName is Success");
		nickName = result.DisplayName;
		onSuccess();
	}

	private void UpdateNickNameFailure(Action onFailure, PlayFabError error){
		Debug.Log(error);
		onFailure();
	}

	public bool LoginCheck(){
		if(PlayFabClientAPI.IsClientLoggedIn())
		{
			return true;
		}
		else{
			return false;
		}
	}
}
