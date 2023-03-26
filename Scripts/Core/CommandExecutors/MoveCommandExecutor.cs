using UnityEngine.AI;
using Abstractions.Commands;
using UnityEngine;
using System.Threading;
using UtilsStrategy;

namespace Strategy
{

    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommandExecutor;
        public override void ExecuteSpecificCommand(IMoveCommand command)
        {
            GoCommand(command.Target);
        }

        public async void GoCommand(Vector3 target)
        {
            GetComponent<NavMeshAgent>().destination = target;
            GetComponent<NavMeshAgent>().avoidancePriority = 99;
            _animator.SetInteger("StateAnim", (int)StateAnimUnit.Run);

            _stopCommandExecutor.CancellationTokenSource = new CancellationTokenSource();
            try
            {
                await _stop
                .WithCancellation
            (
            _stopCommandExecutor
            .CancellationTokenSource
            .Token
            );
            }
            catch
            {
                GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<NavMeshAgent>().ResetPath();
            }
            _stopCommandExecutor.CancellationTokenSource = null;
            _animator.SetInteger("StateAnim", (int)StateAnimUnit.Idle);
            GetComponent<NavMeshAgent>().avoidancePriority = 0;
        }
    }

    }

