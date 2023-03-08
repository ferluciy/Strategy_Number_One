using UnityEngine;
using Abstractions;
using Abstractions.Commands;


namespace Strategy
{

    public class MainUnitMove : CommandExecutorBase<IMoveCommand>
    {

        public override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log("Движение");
        }

    }

}
