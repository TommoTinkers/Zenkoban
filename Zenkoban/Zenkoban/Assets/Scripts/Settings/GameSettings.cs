namespace Zenkoban.Settings
{
	public static class GameSettings
	{
		public const int TileSize = 10;
		public const float BlockMoveDuration = 0.2f;

		public const float LevelSpawnTime = 0.5f;
		public const float LevelDespawnTime = LevelSpawnTime;

		public const float BlockGoalColorChangeDuration = 0.2f;

		public const float BlockJumpDuration = 2f;
		public const int BlockJumpCount = 5;
		public const float BlockJumpPower = 16f;
		public const float CarouselDuration = 0.35f;
		public const float CarouselInOutDuration = 0.5f;
		
		public const int StandardLevelsPerSet = 25;
		public const int BonusLevelsPerSet = 5;
		public const int TotalLevelsPerSet = StandardLevelsPerSet + BonusLevelsPerSet;


		public const string MainMenuSceneName = "MainMenu";
		public const string GameSceneName = "Main";
		public const string CarouselSceneName = "Carousel";
	}
}