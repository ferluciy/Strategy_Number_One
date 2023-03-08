using UnityEngine;
using Abstractions;
using Abstractions.Commands;


namespace Strategy
{

    public class MainUnitPatrol : CommandExecutorBase<IPatrolCommand>
    {

        public override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log("Патруль");
        }

    }

}

