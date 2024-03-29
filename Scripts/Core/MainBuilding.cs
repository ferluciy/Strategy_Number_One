using UnityEngine;
using Abstractions;
using Abstractions.Commands;
using UnityEngine.AI;

namespace Strategy
{

    public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable, IAttackable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform MoveUnitPosition => _moveUnitPosition;
        public Transform RespawnUnitPosition => _respawnUnitPosition;
        public Vector3 RallyPoint { get => _rallyPoint; set => _rallyPoint = value; }
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;
        [SerializeField] private Transform _moveUnitPosition;
        [SerializeField] private Transform _respawnUnitPosition;
        private float _health = 1000;
        [SerializeField] private Vector3 _rallyPoint;

        public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            //var unit = Instantiate(command.UnitPrefab, _respawnUnitPosition.position, Quaternion.identity, _unitsParent);
            //unit.GetComponent<NavMeshAgent>().destination = _moveUnitPosition.position;
            //Animator animator = unit.GetComponent<Animator>();
            //UnitMovementStop stop = unit.GetComponent<UnitMovementStop>();

            //animator.SetInteger("StateAnim", (int)StateAnimUnit.Run);

            //await unit.GetComponent<UnitMovementStop>();

            //animator.SetInteger("StateAnim", (int)StateAnimUnit.Idle);
        }

        public void RecieveDamage(int amount)
        {
            if (_health <= 0)
            {
                return;
            }
            _health -= amount;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }



    }

}