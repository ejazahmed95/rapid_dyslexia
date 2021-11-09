using System;
using System.Collections;
using Activity;
using EAUtils;
using Helpers;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class AppManager: MonoBehaviour {

	private static AppManager instance;
	private ActivityType currentActivity = ActivityType.None;

	[SerializeField] private GameSettings _settings;
	[SerializeField] private GenericDictionary<LanguageType, Locale> _locales = new GenericDictionary<LanguageType, Locale>();

	[SerializeField] private Font _englishFont;
	[SerializeField] private Font _mandarinFont;

	private LanguageType _languageType = LanguageType.Mandarin;
	#region MonoBehaviour Methods
	private void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
			DI.Register(instance);
		} else if (instance != this) {
			Destroy(this);
		}
		DI.Register(_settings);
	}

	private void Start() {
		SetLocale(_settings.languageType);
	}

	#endregion

	public void SetLocale(LanguageType languageType){
		_languageType = languageType;
		if (_locales.TryGetValue(languageType, out Locale value)) {
			Log.i("AM", $"updated the locale to {value}");
			LocalizationSettings.SelectedLocale = value;
		} else {
			Log.e("AM", $"could not locate the locale for language type {languageType}");
		}
	}
	
	public ActivityType GetCurrentActivity() {
		return currentActivity;
	}

	public void SetCurrentActivity(ActivityType aType) {
		currentActivity = aType;
		switch (aType) {
			case ActivityType.None:
				break;
			case ActivityType.WordGame:
				SLoader.LoadScene(Constants.ACTIVITY_SCENE, false);
				break;
			case ActivityType.MathQuiz:
				break;
			case ActivityType.MainScene:
				SLoader.LoadScene(Constants.GAME_SCENE_NAME, false);
				break;
			case ActivityType.CatchAWord:
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(aType), aType, null);
		}
	}

	public IEnumerator CloseActivity() {
		yield return null;
		SLoader.LoadScene(Constants.GAME_SCENE_NAME, false);
	}

	public Font GetFont(){
		var id = LocalizationSettings.SelectedLocale.Identifier.Code;
		if (id == "en"){
			return _englishFont;
		}
		return _mandarinFont;
	}
}

public enum AppState {
	
}