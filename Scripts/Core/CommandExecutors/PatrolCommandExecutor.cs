using UnityEngine;
using Abstractions;
using Abstractions.Commands;


namespace Strategy
{

    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {

        public override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"Начинает патруль {name} от точки {command.StartPosition} до точки {command.EndPosition}");
        }

    }

}

