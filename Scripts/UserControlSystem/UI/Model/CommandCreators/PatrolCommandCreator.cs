using Abstractions.Commands;
using UtilsStrategy;
using System;
using Zenject;
using UnityEngine;

namespace Strategy
{
    public class PatrolCommandCreator :
    CancellableCommandCreatorBase<IPatrolCommand, Vector3>
    {
        [Inject] private SelectableValue _selectable;
        protected override IPatrolCommand createCommand(Vector3 argument) => new
        PatrolCommand(_selectable.CurrentValue.PivotPoint.position, argument);
    }
}

