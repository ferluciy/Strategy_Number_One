using Abstractions.Commands;
using Strategy;
using UniRx;
using UnityEngine;
using static PlasticPipe.PlasticProtocol.Messages.NegotiationCommand;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using Zenject;
using System.ComponentModel;

public class ProduceUnitCommandExecutor :
CommandExecutorBase<IProduceUnitCommand>, IUnitProducer
{
    public IReadOnlyReactiveCollection<IUnitProductionTask> Queue =>
    _queue;
    [SerializeField] private Transform _unitsParent;
    [SerializeField] private int _maximumUnitsInQueue = 6;
    [SerializeField] private MainBuilding _bilding;
    [Inject] private DiContainer _diContainer;
    private ReactiveCollection<IUnitProductionTask> _queue = new
    ReactiveCollection<IUnitProductionTask>();
    private async void Update()
    {
        if (_queue.Count == 0)
        {
            return;
        }
        var innerTask = (UnitProductionTask)_queue[0];
        innerTask.TimeLeft -= Time.deltaTime;
        if (innerTask.TimeLeft <= 0)
        {
            removeTaskAtIndex(0);

            var unit = _diContainer.InstantiatePrefab(innerTask.UnitPrefab, _bilding.RespawnUnitPosition.position, Quaternion.identity, _unitsParent);
            unit.GetComponent<NavMeshAgent>().destination = _bilding.RallyPoint;
            var factionMember = unit.GetComponent<FactionMember>();
            factionMember.SetFaction(GetComponent<FactionMember>().FactionId);
            Animator animator = unit.GetComponent<Animator>();
            UnitMovementStop stop = unit.GetComponent<UnitMovementStop>();

            animator.SetInteger("StateAnim", (int)StateAnimUnit.Run);

            await unit.GetComponent<UnitMovementStop>();

            animator.SetInteger("StateAnim", (int)StateAnimUnit.Idle);
        }
    }
    public void Cancel(int index) => removeTaskAtIndex(index);
    private void removeTaskAtIndex(int index)
    {
        for (int i = index; i < _queue.Count - 1; i++)
{
            _queue[i] = _queue[i + 1];
        }
        _queue.RemoveAt(_queue.Count - 1);
    }
    public override void ExecuteSpecificCommand(IProduceUnitCommand
    command)
    {
    _queue.Add(new UnitProductionTask(command.ProductionTime,
    command.Icon, command.UnitPrefab, command.UnitName));
    }
}