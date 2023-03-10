using UnityEngine;
using Abstractions;
using Abstractions.Commands;


namespace Strategy
{

    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {

        public override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log($"{name} is moving to {command.Target}!");
        }

    }

}
