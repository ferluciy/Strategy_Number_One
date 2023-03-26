using Abstractions.Commands;
using UnityEngine;
using UtilsStrategy;
using Zenject;

namespace Strategy
{
    public class ProduceUnit2Command : IProduceUnit2Command
    {
        [Inject(Id = "Unit2")] public string UnitName { get; }
        [Inject(Id = "Unit2")] public Sprite Icon { get; }
        [Inject(Id = "Unit2")] public float ProductionTime { get; }
        public GameObject UnitPrefab => _unitPrefab;
        [InjectAsset("Unit2")] private GameObject _unitPrefab;

    }

}
