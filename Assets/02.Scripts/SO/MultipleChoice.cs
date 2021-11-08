using System.Collections.Generic;
using EAUtils;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace _02.Scripts.SO {
	[CreateAssetMenu(fileName = "MultipleChoice", menuName = "Questions/MultipleChoice", order = 0)]
	public class MultipleChoice: BaseQuestion {
		public List<LocalizedString> optss = new List<LocalizedString>();
	}
}