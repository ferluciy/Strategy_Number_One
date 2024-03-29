using System;
using UniRx;
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
        [SerializeField] public NavMeshAgent _agent;
        [SerializeField] private CollisionDetector _collisionDetector;
        [SerializeField] private int _throttleFrames = 60;
        [SerializeField] private int _continuityThreshold = 10;
        private void Awake()
        {
        _collisionDetector.Collisions
        .Where(_ => _agent.hasPath)
        .Where(collision => collision.collider.GetComponent<IUnit>() != null)
        .Select(_ => Time.frameCount)
        .Distinct()
        .Buffer(_throttleFrames)
        .Where(buffer => {for (int i=1; i<buffer.Count; i++)
            {
                if (buffer[i] - buffer[i - 1] > _continuityThreshold)
        {
                return false;
            }
        } return true;
})
.Subscribe(_ =>
{
        _agent.isStopped = true;
        _agent.ResetPath();
        OnStop?.Invoke();
    })
.AddTo(this);
}
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
}}
}
    public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);
}
}