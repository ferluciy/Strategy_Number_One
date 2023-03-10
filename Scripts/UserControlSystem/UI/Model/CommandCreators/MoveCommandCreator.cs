using Abstractions.Commands;
using UtilsStrategy;
using System;
using Zenject;
using UnityEngine;

namespace Strategy
{
    public class MoveCommandCreator : CommandCreatorBase<IMoveCommand>
    {
        [Inject] private AssetsContext _context;
        [Inject] private Vector3Value _groundClicks;
        private Action<IMoveCommand> _creationCallback;
        [Inject]
        private void Init()
        {
            _groundClicks.OnNewValue += onNewValue;
        }
        private void onNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new
            MoveCommand(groundClick)));
            _creationCallback = null;
        }
        protected override void
        classSpecificCommandCreation(Action<IMoveCommand> creationCallback)
        {
            _creationCallback = creationCallback;
        }
        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback = null;
        }
    }

}
