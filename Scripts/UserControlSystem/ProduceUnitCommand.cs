using Abstractions.Commands;
using UnityEngine;
using UtilsStrategy;
using Zenject;

namespace Strategy
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        [Inject(Id = "Unit1")] public string UnitName { get; }
        [Inject(Id = "Unit1")] public Sprite Icon { get; }
        [Inject(Id = "Unit1")] public float ProductionTime { get; }
        public GameObject UnitPrefab => _unitPrefab;
        [InjectAsset("Unit1")] private GameObject _unitPrefab;

    }

}
