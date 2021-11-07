using EAUtils;
using Helpers;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager: MonoBehaviour {

	[SerializeField] private LanguageType _languageType;
	[SerializeField] private Button _selectEnglishLocale;
	[SerializeField] private Button _selectMandarinLocale;
	[SerializeField] private Button _gameStartButton;
	
	private void Awake() {
		
	}
	
	private void Start() {
		// _gameText = DI.Get<GameText>();
		// _languageText.text = _gameText.LanguageName;
		// Log.i("MENU", $"Menu started:: {_gameText.LanguageName}");
		_selectEnglishLocale.onClick.AddListener(() => SetLanguageType(LanguageType.English));
		_selectMandarinLocale.onClick.AddListener(() => SetLanguageType(LanguageType.Mandarin));
		_gameStartButton.onClick.AddListener(OnStartClick);
		
		DI.Get<AppManager>().SetLocale(_languageType);
	}

	public void OnStartClick() {
		SLoader.LoadScene(Constants.GAME_SCENE_NAME, false);
	}

	private void SetLanguageType(LanguageType type) {
		_languageType = type;
		DI.Get<AppManager>().SetLocale(_languageType);
	}
}
