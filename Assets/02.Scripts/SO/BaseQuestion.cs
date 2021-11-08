using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace _02.Scripts.SO {
	[CreateAssetMenu(fileName = "BaseQuestion", menuName = "Questions/Base", order = 0)]
	public class BaseQuestion: ScriptableObject {
		public LocalizedString quest;
		public Image questionImage = null;
		public LocalizedString ans;
		public float timeForMaxScore = 2f;
		
	}
}