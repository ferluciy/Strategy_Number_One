using UnityEngine;
using Abstractions;
using Abstractions.Commands;
using UnityEngine.AI;

namespace Strategy
{

    public class MainUnit : MonoBehaviour, ISelectable, IAttackable, IUnit, IDamageDealer
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;
        public int Damage => _damage;
        [SerializeField] private int _damage = 25;

        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;
        [SerializeField] private Animator _animator;
        [SerializeField] private StopCommandExecutor _stopCommand;
        private NavMeshAgent _agent;

        private float _health = 100;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            if (_agent != null) _agent.avoidancePriority = Random.Range(0, 99);
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
                _animator.SetInteger("StateAnim", (int)StateAnimUnit.Death);
                Invoke(nameof(destroy), 1f);
            }
        }

        private void destroy()
        {
            _stopCommand.ExecuteSpecificCommand(new StopCommand());
            Destroy(gameObject);
        }

    }

}