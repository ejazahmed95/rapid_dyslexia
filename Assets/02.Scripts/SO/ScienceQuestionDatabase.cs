using EAUtils;
using UnityEngine;

namespace _02.Scripts.SO {
	[CreateAssetMenu(fileName = "ScienceQuestionDatabase", menuName = "Questions/ScienceDb", order = 0)]
	public class ScienceQuestionDatabase: ScriptableObject {
		public GenericDictionary<BaseQuestion, QuestionPerformanceInfo> questions = new GenericDictionary<BaseQuestion, QuestionPerformanceInfo>();
	}
}