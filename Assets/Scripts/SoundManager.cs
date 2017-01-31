using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource mainMenuSound;
	public AudioSource inGameBackGround;
	public AudioSource damagedSound;
	public float lowPitchRange = .95f;
	public float highPitchRange = 1.05f;
	private static SoundManager _instance = null;
	public static SoundManager instance{
		get{
			if(!_instance){
				_instance = FindObjectOfType(typeof(SoundManager)) as SoundManager;
				if(!_instance){
					GameObject container = new GameObject();
					container.name = "SoundManagerContainer";
					_instance = container.AddComponent(typeof(SoundManager)) as SoundManager;
				}
			}
			return _instance;
		}
	}

	void Start () {
		mainSwitch("mainMenu", true);
	}
	
	public void mainSwitch(string switchName, bool value){
		switch(switchName){
			case "mainMenu":
				mainMenuSoundSwitch(value);
				break;
			case "inGameBackGround":
				inGameBackGroundSwitch(value);
				break;
			case "damagedSound":
				damagedSoundSwitch(value);
				break;
		}
	}

	private void mainMenuSoundSwitch(bool value){
		if (value){
			mainMenuSound.Play();
		}
		else{
			mainMenuSound.Stop();
		}
	}

	private void inGameBackGroundSwitch(bool value){
		if (value){
			inGameBackGround.Play();
		}
		else{
			inGameBackGround.Stop();
		}
	}

	private void damagedSoundSwitch(bool value){
		if (value){
			damagedSound.Play();
		}
		else{
			damagedSound.Stop();
		}
	}
}
