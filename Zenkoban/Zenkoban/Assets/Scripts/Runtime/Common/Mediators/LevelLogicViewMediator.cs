using Sirenix.OdinInspector;
using UnityEngine;
using Zenkoban.Assets.Levels;
using Zenkoban.Input.Movement;
using Zenkoban.Runtime.Data.Movement;
using Zenkoban.Runtime.Levels.Loading;
using Zenkoban.Runtime.Logic;
using Zenkoban.Runtime.Views.Level;
using Zenkoban.Runtime.Views.Level.Factories;

namespace Zenkoban.Runtime.Common.Mediators
{
	public class LevelLogicViewMediator : SerializedMonoBehaviour
	{
		[SerializeField]
		private ILevelAsset levelAsset = null;

		[SerializeField]
		private ILevelLoader levelLoader = null;

		[SerializeField]
		private ILevelTheme levelTheme = null;

		[SerializeField]
		private IMovementInputProvider movementInputProvider = null;

		private IInstantiatedLevelViewFactory instantiatedLevelViewFactory;
		private LevelLogicProcessor logicProcessor;

		private void Awake()
		{
			var level = levelLoader.Load(levelAsset);
			logicProcessor = new LevelLogicProcessor(level);
			instantiatedLevelViewFactory = new InstantiatedLevelViewFactory(levelTheme, transform);
			var viewData = instantiatedLevelViewFactory.Construct(level);
			new LevelView(viewData, logicProcessor);

			movementInputProvider.OnMoveUp += MoveUp;
			movementInputProvider.OnMoveDown += MoveDown;
			movementInputProvider.OnMoveLeft += MoveLeft;
			movementInputProvider.OnMoveRight += MoveRight;
			movementInputProvider.OnUndo += Undo;
		}
		
		private void MoveUp()
		{
			logicProcessor.Move(MoveDirection.Up);
		}
		
		private void MoveDown()
		{
			logicProcessor.Move(MoveDirection.Down);
		}
		
		private void MoveLeft()
		{
			logicProcessor.Move(MoveDirection.Left);
		}
		
		private void MoveRight()
		{
			logicProcessor.Move(MoveDirection.Right);
		}
		
		private void Undo()
		{
			logicProcessor.Undo();
		}
	}
}