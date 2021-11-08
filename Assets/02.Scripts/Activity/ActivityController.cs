using System.Collections.Generic;
using EAUtils;
using UnityEngine;

namespace Activity {
	public class ActivityController: MonoBehaviour {
		[SerializeField] private GenericDictionary<ActivityType, GameObject> _activities = new GenericDictionary<ActivityType, GameObject>();
		[SerializeField] private ActivityType currentActivity = ActivityType.None;
		
		private void Start() {
			currentActivity = DI.Get<AppManager>().GetCurrentActivity();
			if (currentActivity == ActivityType.None) {
				Log.e("ActivityController", "error loading activity");
				return;
			}

			if (_activities.TryGetValue(currentActivity, out GameObject obj)) {
				obj.SetActive(true);
			}
		}
	}
}