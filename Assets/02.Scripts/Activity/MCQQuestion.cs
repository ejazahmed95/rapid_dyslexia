using System.Collections.Generic;
using _02.Scripts.SO;
using _02.Scripts.View;
using Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Activity {
	public class MCQQuestion: MonoBehaviour, IQuestion {

		[SerializeField] private DynamicLocalizer _questionText;
		[SerializeField] private List<DynamicLocalizer> _optionTexts = new List<DynamicLocalizer>();
		[SerializeField] private List<Button> _options = new List<Button>();
		
		private MultipleChoice _questionInfo;
		private UnityEvent<bool> _onAnswered = new UnityEvent<bool>();

		private void Start() {
			//Validation
			_options[0].onClick.AddListener(() => ClickedOption(0));
			_options[1].onClick.AddListener(() => ClickedOption(1));
			_options[2].onClick.AddListener(() => ClickedOption(2));
			_options[3].onClick.AddListener(() => ClickedOption(3));
		}

		private void ClickedOption(int index) {
			_onAnswered.Invoke(index == _questionInfo.answ);
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
			_onAnswered.AddListener(onAnswered);
		}
	}
}

