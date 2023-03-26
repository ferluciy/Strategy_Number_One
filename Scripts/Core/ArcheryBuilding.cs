using UnityEngine;
using Abstractions;
using Abstractions.Commands;
using UnityEngine.AI;

namespace Strategy
{

    public class ArcheryBuilding : CommandExecutorBase<IProduceUnit2Command>, ISelectable, IAttackable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform MoveUnitPosition => _moveUnitPosition;
        public Transform RespawnUnitPosition => _respawnUnitPosition;
        public Vector3 RallyPoint { get => _rallyPoint; set => _rallyPoint = value; }
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private float _maxHealth = 500;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;
        [SerializeField] private Transform _moveUnitPosition;
        [SerializeField] private Transform _respawnUnitPosition;
        private float _health = 500;
        [SerializeField] private Vector3 _rallyPoint;

        public override void ExecuteSpecificCommand(IProduceUnit2Command command)
        {
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