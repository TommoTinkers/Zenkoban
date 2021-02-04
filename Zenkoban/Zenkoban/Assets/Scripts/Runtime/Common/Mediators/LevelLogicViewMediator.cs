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
using static Zenkoban.Utils.Combinators.Combinators;

namespace Zenkoban.Runtime.Common.Mediators
{
	public class LevelLogicViewMediator : SerializedMonoBehaviour, IBeginnableLevelContext, IActivatable
	{
		[SerializeField]
		private ILevelTheme levelTheme = null;

		[SerializeField]
		private IMovementInputProvider movementInputProvider = null;

		[SerializeField]
		private PlayableDirector endOfLevelTimeline = null;
		
		private LevelLogicProcessor logicProcessor;

		private bool isActive = true;
		
		public void Initialise(Level level)
		{
			logicProcessor = new LevelLogicProcessor(level);
			var instantiatedLevelViewFactory = new InstantiatedLevelViewFactory(levelTheme, transform);
			var viewData = instantiatedLevelViewFactory.Construct(level);
			new LevelView(viewData, logicProcessor, level, FindObjectOfType<InGameEventSystem>());
		}

		public void Begin(Action onCompleteCallback)
		{
			SubscribeToControls();
			endOfLevelTimeline.stopped += d => onCompleteCallback();
			logicProcessor.OnLevelComplete += endOfLevelTimeline.Play;
		}

		private void SubscribeToControls()
		{
			var ifActiveDo = IfThen(() => isActive);

			movementInputProvider.OnMoveUp += ifActiveDo(MoveUp);
			movementInputProvider.OnMoveDown += ifActiveDo(MoveDown);
			movementInputProvider.OnMoveLeft += ifActiveDo(MoveLeft);
			movementInputProvider.OnMoveRight += ifActiveDo(MoveRight);
			movementInputProvider.OnUndo += ifActiveDo(Undo);
		}

		private void MoveUp() => logicProcessor.AttemptMove(MoveDirection.Up);
		private void MoveDown() => logicProcessor.AttemptMove(MoveDirection.Down);
		private void MoveLeft() => logicProcessor.AttemptMove(MoveDirection.Left);
		private void MoveRight() => logicProcessor.AttemptMove(MoveDirection.Right);
		private void Undo() => logicProcessor.Undo();
		

		public void SetActive() => isActive = true;
		public void SetInactive() => isActive = false;
	}
}