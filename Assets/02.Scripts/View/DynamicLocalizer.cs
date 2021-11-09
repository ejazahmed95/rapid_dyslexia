using EAUtils;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace _02.Scripts.View {
	[RequireComponent(typeof(LocalizeStringEvent))]
	public class DynamicLocalizer: MonoBehaviour {

		private LocalizeStringEvent _localizerEvent;
		private Text _text;
		
		private void Start() {
			_localizerEvent = GetComponent<LocalizeStringEvent>();
			_text = GetComponent<Text>();
		}

		public void UpdateLocale(){
			_text.font = DI.Get<AppManager>().GetFont();
		}
		
		public void UpdateLocalizedString(LocalizedString newString) {
			// Sets the reference and also updates the change handler
			_localizerEvent.StringReference = newString;
		}
	}
}