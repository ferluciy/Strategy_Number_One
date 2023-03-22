using UnityEngine;
using Abstractions;
using Abstractions.Commands;


namespace Strategy
{

    public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {

        public override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log($"{name} is attack to {command.Target}!");
        }

    }

}