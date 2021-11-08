using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

namespace _02.Scripts.View {
	[RequireComponent(typeof(LocalizeStringEvent))]
	public class DynamicLocalizer: MonoBehaviour {

		private LocalizeStringEvent _localizerEvent;
		
		private void Start() {
			_localizerEvent = GetComponent<LocalizeStringEvent>();
		}

		public void UpdateLocalizedString(LocalizedString newString) {
			// Sets the reference and also updates the change handler
			_localizerEvent.StringReference = newString;
		}
	}
}