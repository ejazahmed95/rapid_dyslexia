using UnityEngine;
using UnityEngine.UI;

namespace _02.Scripts.SO {
	[CreateAssetMenu(fileName = "BaseQuestion", menuName = "Questions/Base", order = 0)]
	public class BaseQuestion: ScriptableObject {
		public string question;
		public Image questionImage = null;
		public string answer;
	}
}