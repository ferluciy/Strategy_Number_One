using Abstractions.Commands;
using UtilsStrategy;
using System;
using Zenject;
using UnityEngine;

namespace Strategy
{
    public class MoveCommandCreator :
    CancellableCommandCreatorBase<IMoveCommand, Vector3>
    {
        protected override IMoveCommand createCommand(Vector3 argument) => new
        MoveCommand(argument);
    }

}
