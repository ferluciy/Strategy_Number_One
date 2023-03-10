using Abstractions.Commands;
using UtilsStrategy;
using System;
using Zenject;
using UnityEngine;

namespace Strategy
{
    public class PatrolCommandCreator : CommandCreatorBase<IPatrolCommand>
    {
        [Inject] private AssetsContext _context;
        [Inject] private SelectableValue _selectable;
        [Inject] private Vector3Value _groundClicks;
        private Action<IPatrolCommand> _creationCallback;
        [Inject]
        private void Init()
        {
            _groundClicks.OnNewValue += onNewValue;
        }
        private void onNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new
            PatrolCommand(_selectable.CurrentValue.PivotPoint.position, groundClick)));
            _creationCallback = null;
        }
        protected override void classSpecificCommandCreation(Action<IPatrolCommand>
        creationCallback)
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

