using EAUtils;
using TMPro;
using UnityEngine;

namespace _02.Scripts {
	public class MenuManager: MonoBehaviour {
		[SerializeField] private TMP_Text _languageText;

		private GameText _gameText;

		private void Start() {
			_gameText = DI.Get<GameText>();
			_languageText.text = _gameText.LanguageName;
			Log.i("MENU", $"Menu started:: {_gameText.LanguageName}");
		}
	}
}