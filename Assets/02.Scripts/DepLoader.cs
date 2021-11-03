using EAUtils;
using UnityEngine;

public class DepLoader: MonoBehaviour {
	// Singleton Object References
	// [SerializeField] private GameObject gameManager = null;
	[SerializeField] private GameObject sceneLoader = null;
	[SerializeField] private GameText languageSettings = null;

	// state
	private static bool initialised;

	private void Awake() {
		if (initialised || !Validate()) {
			Destroy(gameObject);
			return;
		}
		Log.i(name, "Instantiating game dependencies");
		Instantiate(sceneLoader);
		// Instantiate(gameManager);
		DI.Register(languageSettings);
		// todo: disable debugger through code (or) add different debugging.
		initialised = true;
	}
	
	private bool Validate() {
		var isValid = sceneLoader && languageSettings;
		if (!isValid) {
			Log.e(name, $"Missing references:: " +
						   $"Manager=[] || SceneLoader={sceneLoader} || LanguageSettings={languageSettings} ");
		}
		return isValid;
	}
}