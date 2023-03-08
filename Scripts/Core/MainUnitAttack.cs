using UnityEngine;
using Abstractions;
using Abstractions.Commands;


namespace Strategy
{

    public class MainUnitAttack : CommandExecutorBase<IAttackCommand>
    {

        public override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log("Атака");
        }

    }

}