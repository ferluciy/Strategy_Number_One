using Abstractions.Commands;
using UtilsStrategy;
using System;
using Zenject;
using UnityEngine;

namespace Strategy
{
    public class ProduceUnit2CommandCommandCreator :
    CommandCreatorBase<IProduceUnit2Command>
    {
        [Inject] private AssetsContext _context;
        [Inject] private DiContainer _diContainer;
        protected override void
        classSpecificCommandCreation(Action<IProduceUnit2Command> creationCallback)
        {
            Debug.Log("Команда 2 создана");
            var produceUnitCommand = _context.Inject(new
            ProduceUnit2Command());
            _diContainer.Inject(produceUnitCommand);
            creationCallback?.Invoke(produceUnitCommand);
        }
    }

}