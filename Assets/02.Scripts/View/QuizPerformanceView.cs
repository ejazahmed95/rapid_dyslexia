using _02.Scripts.SO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _02.Scripts.View {
	public class QuizPerformanceView: MonoBehaviour {
		public UnityEvent onEnd = new UnityEvent();
		[SerializeField] private Button _closeButton;
		[SerializeField] private Text _correctQuestionsText;
		[SerializeField] private Text _incorrectQuestionsText;

		private void Start() {
			_closeButton.onClick.AddListener(onClose);
		}

		public void EnableView(QuizPerformanceInfo quizPerfInfo) {
			gameObject.SetActive(true);
			_correctQuestionsText.text   = $"ÕýÈ· : {quizPerfInfo.answeredCorrect}";
			_incorrectQuestionsText.text = $"´íÎó   : {quizPerfInfo.answeredIncorrect}";
		}

		private void onClose() {
			onEnd.Invoke();
		}
		
		
		
	}
}