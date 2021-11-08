using System.Collections.Generic;
using _02.Scripts.SO;
using _02.Scripts.View;
using Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Activity {
	public class MCQQuestion: MonoBehaviour, IQuestion {

		[SerializeField] private DynamicLocalizer _questionText;
		[SerializeField] private List<DynamicLocalizer> _optionTexts = new List<DynamicLocalizer>();

		private MultipleChoice _questionInfo;

		private void Start() {
			//Validation
			
		}

		public void PopulateQuestion(BaseQuestion question) {
			if (Helpers.Utils.TryConvertVal(question, out MultipleChoice q)) {
				_questionInfo = q;
				_questionText.UpdateLocalizedString(q.quest);
				_optionTexts[0].UpdateLocalizedString(q.optss[0]);
				_optionTexts[1].UpdateLocalizedString(q.optss[1]);
				_optionTexts[2].UpdateLocalizedString(q.optss[2]);
				_optionTexts[3].UpdateLocalizedString(q.optss[3]);
			}
		}

		public void RegisterOnAnsweredCallback(UnityAction<bool> onAnswered) {
			
		}
	}
}

