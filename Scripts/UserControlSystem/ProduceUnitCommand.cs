using Abstractions.Commands;
using UnityEngine;
using UtilsStrategy;

namespace Strategy
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        public GameObject UnitPrefab => _unitPrefab;
        [InjectAssetAttribute("Unit1")] private GameObject _unitPrefab;
      
    }

}
