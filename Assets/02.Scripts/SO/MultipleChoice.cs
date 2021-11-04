using UnityEngine;
using UnityEngine.UI;

namespace _02.Scripts.SO {
	[CreateAssetMenu(fileName = "MultipleChoice", menuName = "Questions/MultipleChoice", order = 0)]
	public class MultipleChoice: BaseQuestion {
		public string[] options;
	}
}