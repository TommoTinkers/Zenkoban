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
using Zenkoban.Utils.Combinators;

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
			var WhenActiveDo = Combinators.If(() => isActive);

			movementInputProvider.OnMoveUp += WhenActiveDo(MoveUp);
			movementInputProvider.OnMoveDown += WhenActiveDo(MoveDown);
			movementInputProvider.OnMoveLeft += WhenActiveDo(MoveLeft);
			movementInputProvider.OnMoveRight += WhenActiveDo(MoveRight);
			movementInputProvider.OnUndo += WhenActiveDo(Undo);
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

		public void SetActive() => isActive = true;
		public void SetInactive() => isActive = false;
	}
}