using System.Collections.Generic;
using EAUtils;
using UnityEngine;

namespace Activity {
	public class ActivityController: MonoBehaviour {
		[SerializeField] private GenericDictionary<ActivityType, ActivityManager> _activityManagers = new GenericDictionary<ActivityType, ActivityManager>();
		[SerializeField] private ActivityType currentActivity = ActivityType.None;
		
		private void Start() {
			currentActivity = DI.Get<AppManager>().GetCurrentActivity();
			if (currentActivity == ActivityType.None) {
				Log.e("ActivityController", "error loading activity");
			}
		}
	}
}