using Abstractions.Commands;
using UtilsStrategy;
using System;
using Zenject;
using UnityEngine;

namespace Strategy { 
public class ProduceUnitCommandCommandCreator :
CommandCreatorBase<IProduceUnitCommand>
{
        [Inject] private AssetsContext _context;
        [Inject] private DiContainer _diContainer;
        protected override void
        classSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
        {
            Debug.Log("������� 1 �������");
            var produceUnitCommand = _context.Inject(new
            ProduceUnitCommandHeir());
            _diContainer.Inject(produceUnitCommand);
            creationCallback?.Invoke(produceUnitCommand);
        }
    }

}