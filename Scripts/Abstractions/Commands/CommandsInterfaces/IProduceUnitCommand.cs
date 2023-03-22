using UnityEngine;

namespace Abstractions.Commands { 
public interface IProduceUnitCommand : ICommand, IIconHolder
    {
        float ProductionTime { get; }
        GameObject UnitPrefab { get; }
        string UnitName { get; }
    }

}