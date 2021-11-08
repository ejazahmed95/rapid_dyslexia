namespace _02.Scripts.SO {
	public struct QuestionPerformanceInfo {
		public int timesAsked, timesCorrect, timesIncorrect;
	}

	public struct QuizPerformanceInfo {
		public int totalTimeTaken;
		public int numberOfQuestions;
		public int answeredCorrect, answeredIncorrect;
		public int score;
		public float scoreInPercentage;
	}
}