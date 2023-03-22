using UnityEngine;
using Abstractions;
using Abstractions.Commands;
using UnityEngine.AI;

namespace Strategy
{

    public class MainUnit : MonoBehaviour, ISelectable, IAttackable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;

        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;
        private NavMeshAgent _agent;

        private float _health = 100;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            if (_agent != null) _agent.avoidancePriority = Random.Range(0, 99);
        }

    }

}