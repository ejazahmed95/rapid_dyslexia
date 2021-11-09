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
		private int _currentQIndex = 0;
		private QuizPerformanceInfo _quizPerfInfo;

		private void Start() {
			_quizPerformanceView.onEnd.AddListener(endQuiz);
			StartQuiz();
		}

		public override void StartQuiz() {
			_rGen = new Random(DateTime.Now.Millisecond);
			_questions.Clear();
			
			int size = _db.questions.Count;
			_questions = _db.questions.ToList();
			_quizInProgress = true;
			_currentQIndex = 0;
			_quizPerfInfo = new QuizPerformanceInfo{numberOfQuestions = numQuestions};
			
			StartCoroutine(populateNextQuestion());
		}

		private IEnumerator populateNextQuestion() {
			yield return null;
			if(_currentQIndex > numQuestions) quizCompleted();
			
			BaseQuestion question = _questions[_rGen.Next(0, _questions.Count)].Key;
			IQuestion obj = getObjectForQuestionType(question);
			obj.PopulateQuestion(question);
			obj.RegisterOnAnsweredCallback(onQuestionAnswered);
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
			endQuiz();
		}

		private void endQuiz(){
			var stress = _quizPerfInfo.answeredIncorrect * 30;
			DI.Get<StatsController>().UpdateStress(stress);
			StartCoroutine(DI.Get<AppManager>().CloseActivity());
		}

		private IQuestion getObjectForQuestionType(BaseQuestion key) {
			return _mcqQuestion;
		}
	}
}