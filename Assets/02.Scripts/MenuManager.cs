using EAUtils;
using Helpers;
using TMPro;
using UnityEngine;

namespace _02.Scripts {
	public class MenuManager: MonoBehaviour {
		[SerializeField] private TMP_Text _languageText;

		private GameText _gameText;
		private SLoader _sLoader;

		private void Awake() {
			
		}
		
		private void Start() {
			_gameText = DI.Get<GameText>();
			_languageText.text = _gameText.LanguageName;
			Log.i("MENU", $"Menu started:: {_gameText.LanguageName}");
		}

		public void OnStartClick() {
			SLoader.LoadScene(Constants.GAME_SCENE_NAME, false);
		}
	}
}