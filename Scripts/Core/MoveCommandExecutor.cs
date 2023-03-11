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
        public override async void ExecuteSpecificCommand(IMoveCommand command)
        {
            GetComponent<NavMeshAgent>().destination = command.Target;
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
        }
    }

    }

