using Abstractions.Commands;
using UtilsStrategy;
using System;
using Zenject;
using UnityEngine;
using Abstractions;

namespace Strategy
{
    public class AttackCommandCreator : CommandCreatorBase<IAttackCommand>
    {

        [Inject] private AssetsContext _context;
        [Inject] private AttackableValue _attackable;
        private Action<IAttackCommand> _creationCallback;
        [Inject]
        private void Init()
        {
            _attackable.OnNewValue += onNewValue;
        }
        private void onNewValue(IAttackable attackable)
        {
            _creationCallback?.Invoke(_context.Inject(new
            AttackCommand(attackable)));
            _creationCallback = null;
        }
        protected override void
        classSpecificCommandCreation(Action<IAttackCommand> creationCallback)
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