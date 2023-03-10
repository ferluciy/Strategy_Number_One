using UnityEngine;
using Abstractions;
using Abstractions.Commands;


namespace Strategy
{

    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {

        public override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"�������� ������� {name} �� ����� {command.StartPosition} �� ����� {command.EndPosition}");
        }

    }

}

