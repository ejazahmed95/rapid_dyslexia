using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace _02.Scripts.SO {
	[CreateAssetMenu(fileName = "MultipleChoice", menuName = "Questions/MultipleChoice", order = 0)]
	public class MultipleChoice: BaseQuestion {
		public List<LocalizedString> optss = new List<LocalizedString>();
		public int answ = 0;
	}
}