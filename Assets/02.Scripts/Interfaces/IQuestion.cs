using _02.Scripts.SO;
using UnityEngine.Events;

namespace Interfaces {
	public interface IQuestion {
		void PopulateQuestion(BaseQuestion question);
		void RegisterOnAnsweredCallback(UnityAction<bool> onAnswered);
	}
}

