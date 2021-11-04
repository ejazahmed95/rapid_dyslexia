using EAUtils;
using UnityEngine;

public class DepLoader: MonoBehaviour {
	// Singleton Object References
	// [SerializeField] private GameObject gameManager = null;
	[SerializeField] private SLoader sceneLoader = null;
	[SerializeField] private AppManager appManager = null;
	[SerializeField] private GameText languageSettings = null;
	[SerializeField] private StatsController _statsController = null;

	// state
	private static bool initialised;

	private void Awake() {
		if (initialised || !Validate()) {
			Destroy(gameObject);
			return;
		}
		Log.i(name, "Instantiating game dependencies");
		Instantiate(sceneLoader);
		Instantiate(appManager);
		DI.Register(languageSettings);
		// todo: disable debugger through code (or) add different debugging.
		initialised = true;
	}
	
	private bool Validate() {
		var isValid = sceneLoader && appManager;
		if (!isValid) {
			Log.e(name, $"Missing references:: " +
						   $"Manager={appManager} || SceneLoader={sceneLoader} || LanguageSettings={languageSettings} ");
		}
		return isValid;
	}
}