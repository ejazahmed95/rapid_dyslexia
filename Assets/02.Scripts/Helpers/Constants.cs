namespace Helpers {
	internal static class Constants {
		public const float WALL_DESTROY_TIME = 0.1f;
		public const string playerId    = "player_id";
		public const string idSeparator = "-";
		public const int    firstLevel  = 0;

		public const float gridMovementPadding = .3f;

		// Default Player Configs
		public const float DEF_SPEED          = 5f;
		public const float DEF_SPEED_BOOST    = 0;
		public const int   DEF_BOMB_LIMIT     = 3;
		public const int   BASE_BOMB_POWER    = 1;
		public const int   DEF_BOMB_TIMER     = 3000;
		public const float DEF_EXPLOSION_TIME = 1f;
		public const float DEF_EXPLOSION_SPEED = 10f;
		
		// Scene Names
		public const string MENU_SCENE_NAME = "MenuScene";
		public const string GAME_SCENE_NAME = "MainScene";
		public const string ACTIVITY_SCENE = "WordGame";
		public const string END_SCENE_NAME = "EndScene";

		#region Strings

		// GameEnd UI
		public const string headerLevelComplete = "Stage Cleared";
		public const string headerGameComplete = "Congratulations!!";
		public const string headerTimeUp = "Time Up!";
		public const string headerPlayerDied = "You Died!";
		public const string headerGameOver = "Game Over";

		#endregion

	}
}