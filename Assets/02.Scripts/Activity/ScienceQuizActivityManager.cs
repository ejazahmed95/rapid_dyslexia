using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _02.Scripts.SO;
using _02.Scripts.View;
using EAUtils;
using Interfaces;
using UnityEngine;
using Random = System.Random;

namespace Activity {
	public class ScienceQuizActivityManager: ActivityManager {
		[SerializeField] private ScienceQuestionDatabase _db;
		[SerializeField] private int numQuestions = 3;
		[SerializeField] private MCQQuestion _mcqQuestion;
		[SerializeField] private QuizPerformanceView _quizPerformanceView;

		private List<KeyValuePair<BaseQuestion, QuestionPerformanceInfo>> _questions = new List<KeyValuePair<BaseQuestion, QuestionPerformanceInfo>>();
		private Random _rGen;
		private bool _quizInProgress = false;
		[SerializeField] private int _currentQIndex = 0;
		private QuizPerformanceInfo _quizPerfInfo;
		private List<int> qOrder;

		private void Start() {
			_quizPerformanceView.onEnd.AddListener(endQuiz);
			qOrder = Enumerable.Range(0, _db.questions.Count).ToList();
			StartQuiz();
		}

		public override void StartQuiz() {
			_rGen = new Random(DateTime.Now.Millisecond);
			qOrder = qOrder.OrderBy(id => _rGen.Next()).ToList();
			_questions.Clear();
			
			_mcqQuestion.gameObject.SetActive(true);
			_quizPerformanceView.gameObject.SetActive(false);
			
			int size = _db.questions.Count;
			_questions = _db.questions.ToList();
			_quizInProgress = true;
			_currentQIndex = 0;
			_quizPerfInfo = new QuizPerformanceInfo{numberOfQuestions = numQuestions};
			
			StartCoroutine(populateNextQuestion());
			_mcqQuestion.RegisterOnAnsweredCallback(onQuestionAnswered);
		}

		private IEnumerator populateNextQuestion() {
			yield return null;
			if (_currentQIndex >= numQuestions) {
				quizCompleted();
				yield break;
			}
			
			BaseQuestion question = _questions[qOrder[_currentQIndex]].Key;
			IQuestion obj = getObjectForQuestionType(question);
			obj.PopulateQuestion(question);
			// obj.RegisterOnAnsweredCallback(onQuestionAnswered);
			_currentQIndex++;
		}

		private void onQuestionAnswered(bool correct) {
			if (correct) {
				_quizPerfInfo.answeredCorrect++;
				_quizPerfInfo.score += 10;
			} else {
				_quizPerfInfo.answeredIncorrect++;
			}
			StartCoroutine(populateNextQuestion());
		}

		private void quizCompleted() {
			_quizPerformanceView.EnableView(_quizPerfInfo);
			_mcqQuestion.gameObject.SetActive(false);
			var stress = _quizPerfInfo.answeredIncorrect * 15;
			DI.Get<StatsController>().UpdateStress(stress);
		}

		private void endQuiz(){
			StartCoroutine(DI.Get<AppManager>().CloseActivity());
		}

		private IQuestion getObjectForQuestionType(BaseQuestion key) {
			return _mcqQuestion;
		}
	}
}