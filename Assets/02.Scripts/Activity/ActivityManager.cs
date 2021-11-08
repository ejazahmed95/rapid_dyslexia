using UnityEngine;

namespace Activity {
	public abstract class ActivityManager: MonoBehaviour {

		private void OnDestroy() {
			
		}

		public abstract void StartQuiz();
		
		
	}
}