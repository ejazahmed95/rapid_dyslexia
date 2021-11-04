using System;
using Activity;
using EAUtils;
using Helpers;
using UnityEngine;

public class AppManager: MonoBehaviour {
	#region MonoBehaviour Methods

	private static AppManager instance;
	private ActivityType currentActivity = ActivityType.None;
	
	private void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
			DI.Register(instance);
		} else if (instance != this) {
			Destroy(this);
		}
	}
	#endregion

	public ActivityType GetCurrentActivity() {
		return currentActivity;
	}

	public void SetCurrentActivity(ActivityType aType) {
		currentActivity = aType;
		switch (aType) {
			case ActivityType.None:
				break;
			case ActivityType.WordGame:
				SLoader.LoadScene("ActivityScene", false);
				break;
			case ActivityType.MathQuiz:
				break;
			case ActivityType.ReadingQuiz:
				break;
			case ActivityType.CatchAWord:
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(aType), aType, null);
		}
	}

	public void CloseActivity() {
		SLoader.LoadScene(Constants.GAME_SCENE_NAME, false);
	}
}

public enum AppState {
	
}