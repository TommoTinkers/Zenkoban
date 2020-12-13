using System;
using System.Linq;
using Zenkoban.Assets.Flow.Levels;

namespace Zenkoban.Extensions.Data.Levels
{
	public static class GameLevelsConfigurationExtensions
	{
		public static (bool, string) Validate(this GameLevelsConfiguration levelsConfig)
		{
			if (!levelsConfig.MainLevels?.Any() ?? false)
			{
				return (false, "No level sets defined");
			}

			if (levelsConfig.MainLevels.Any(s => s == null))
			{
				return (false, "Level configuration contains at least one level set that is null.");
			}
			
			foreach (var set in levelsConfig.MainLevels)
			{
				if (!set.AllLevels.Any())
				{
					return (false, "Level confgiruation contains at least one empty level set.");
				}

				if (set.AllLevels.Any(l => l == null))
				{
					return (false, "A null level entry exist in the games level configuration");
				}
			}

			return (true, "Ok");
		}

		public static void AssetIsValid(this GameLevelsConfiguration levelsConfig)
		{
			var (result, message) = levelsConfig.Validate();
			if (!result)
			{
				throw new Exception($"Invalid level set {message}");
			}
		}
	}
}