using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EAUtils {
	public class SLoader: MonoBehaviour {
	
		private static SLoader      instance;
		private static List<string> scenesList;
		
		private static string sceneToLoad = "";
		private static string loadingScene = "";
		private static AsyncOperation asyncLoad;
		
		#region MonoBehaviour Methods

		private void Awake() {
			if (instance == null) {
				instance = this;
				DontDestroyOnLoad(gameObject);
			} else if (instance != this) {
				Destroy(this);
			}
			scenesList = new List<string>();
			for (var i = 1; i < SceneManager.sceneCountInBuildSettings; i++) {
				var scenePath = SceneUtility.GetScenePathByBuildIndex(i);
				var lastSlash = scenePath.LastIndexOf("/", StringComparison.Ordinal);
				scenesList.Add(scenePath.Substring(lastSlash + 1,
					scenePath.LastIndexOf(".", StringComparison.Ordinal) - lastSlash - 1));
			}
		}

		#endregion

		public static void RegisterLoadingScene(string name) {
			if (!scenesList.Contains(name)) {
				Log.e("SLoader", $"invalid name provided for the load scene: {name}");
				return;
			}
			loadingScene = name;
		}

		public static void LoadNextScene(bool loadAsync) {
			// TODO: Implementation
		}
		
		public static void LoadScene(string sceneName, bool loadAsync) {
			if (!scenesList.Contains(sceneName)) {
				Log.e("SLoader", $"invalid name provided for loading the scene: {sceneName}");
				return;
			}
			if (asyncLoad!= null && !asyncLoad.isDone) {
				Log.e("SLoader", $"cannot load scene, another scene being loaded: {sceneToLoad}");
				return;
			}
			
			// Loading the existing scene
			if (!loadAsync || loadingScene.Equals("")) {
				SceneManager.LoadScene(sceneName);
				return;
			}
			
			// Load the loading scene
			sceneToLoad = sceneName;
			SceneManager.LoadScene(loadingScene);
			instance.StartCoroutine(LoadSceneAsync());
		}

		public static IEnumerator LoadSceneAsync() {
			yield return null;

			asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);	
			while (!asyncLoad.isDone) {
				yield return null;
			}
			asyncLoad = null;
		}

		public static float GetProgress() {
			return asyncLoad?.progress ?? 1f;
		}

		public static string GetCurrentScene() {
			return sceneToLoad;
		}
	}
}