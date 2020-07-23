using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Playables;
using Zenkoban.Input.Movement;
using Zenkoban.Runtime.Data.Levels;
using Zenkoban.Runtime.Data.Movement;
using Zenkoban.Runtime.Events.InGameEvents;
using Zenkoban.Runtime.Logic;
using Zenkoban.Runtime.Views.Level;
using Zenkoban.Runtime.Views.Level.Factories;

namespace Zenkoban.Runtime.Common.Mediators
{
	public class LevelLogicViewMediator : SerializedMonoBehaviour
	{
		[SerializeField]
		private ILevelTheme levelTheme = null;

		[SerializeField]
		private IMovementInputProvider movementInputProvider = null;

		[SerializeField]
		private PlayableDirector endOfLevelTimeline = null;
		
		private LevelLogicProcessor logicProcessor;
		
		public void Initialise(Level level)
		{
			logicProcessor = new LevelLogicProcessor(level);
			var instantiatedLevelViewFactory = new InstantiatedLevelViewFactory(levelTheme, transform);
			var viewData = instantiatedLevelViewFactory.Construct(level);
			new LevelView(viewData, logicProcessor, level, FindObjectOfType<InGameEventSystem>());
		}

		public void Begin(Action onCompleteCallback)
		{
			movementInputProvider.OnMoveUp += MoveUp;
			movementInputProvider.OnMoveDown += MoveDown;
			movementInputProvider.OnMoveLeft += MoveLeft;
			movementInputProvider.OnMoveRight += MoveRight;
			movementInputProvider.OnUndo += Undo;

			endOfLevelTimeline.stopped += d => onCompleteCallback();
			logicProcessor.OnLevelComplete += endOfLevelTimeline.Play;
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