
using UnityEngine;
using Abstractions;
using Abstractions.Commands;


namespace Strategy
{

    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {

        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            Debug.Log("Стоп");
        }

    }

}

