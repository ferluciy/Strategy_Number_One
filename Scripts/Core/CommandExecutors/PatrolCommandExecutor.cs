using UnityEngine;
using Abstractions.Commands;
using UnityEngine.AI;
using System.Threading;
using UtilsStrategy;

namespace Strategy
{

    public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
    {

        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;
        public override async void ExecuteSpecificCommand(IPatrolCommand
        command)
        {
            var point1 = command.StartPosition;
            var point2 = command.EndPosition;
            while (true)
            {
                GetComponent<NavMeshAgent>().destination = point2;
                _animator
                .SetInteger("StateAnim", (int)StateAnimUnit.Run);
                _stopCommandExecutor.CancellationTokenSource = new
                CancellationTokenSource();
                try
                {
                    await
                    _stop.WithCancellation(_stopCommandExecutor.CancellationTokenSource.Token);
                }
catch
                {
                    GetComponent<NavMeshAgent>().isStopped = true;
                    GetComponent<NavMeshAgent>().ResetPath();
                    break;
                }
                var temp = point1;
                point1 = point2;
                point2 = temp;
            }
            _stopCommandExecutor.CancellationTokenSource = null;
            _animator.SetInteger("StateAnim", (int)StateAnimUnit.Idle);
        }
    }

}



