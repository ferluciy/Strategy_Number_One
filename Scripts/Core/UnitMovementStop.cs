using System;
using UnityEngine;
using UnityEngine.AI;
using UtilsStrategy;

namespace Strategy { 

    public enum StateAnimUnit
    {
        Idle = 0,
        Run = 1,
        Attack1 = 2,
        Attack2 = 3,
        Death = 4
    }
public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
{
        public class StopAwaiter : AwaiterBase<AsyncExtensions.Void>
        {
            private readonly UnitMovementStop _unitMovementStop;
public StopAwaiter(UnitMovementStop unitMovementStop)
            {
                _unitMovementStop = unitMovementStop;
                _unitMovementStop.OnStop += onStop;
            }
            private void onStop()
            {
                _unitMovementStop.OnStop -= onStop;
                onWaitFinish(new AsyncExtensions.Void());
            }
        }
        public event Action OnStop;
    [SerializeField] private NavMeshAgent _agent;
    void Update()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
{
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
{
                    OnStop?.Invoke();
}
            }
        }
    }
    public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);
}
}