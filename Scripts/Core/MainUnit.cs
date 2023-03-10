using UnityEngine;
using Abstractions;
using Abstractions.Commands;


namespace Strategy
{

    public class MainUnit : MonoBehaviour, ISelecatable, IAttackable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;

        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;

        private float _health = 100;



    }

}