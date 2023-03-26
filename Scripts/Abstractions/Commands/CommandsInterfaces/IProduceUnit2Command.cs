using UnityEngine;

namespace Abstractions.Commands
{
    public interface IProduceUnit2Command : ICommand, IIconHolder
    {
        float ProductionTime { get; }
        GameObject UnitPrefab { get; }
        string UnitName { get; }
    }

}