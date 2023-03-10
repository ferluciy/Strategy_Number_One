using Abstractions.Commands;
using UtilsStrategy;
using System;
using Zenject;

namespace Strategy { 
public class ProduceUnitCommandCommandCreator :
CommandCreatorBase<IProduceUnitCommand>
{
    [Inject] private AssetsContext _context;
    protected override void
    classSpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
    {
        creationCallback?.Invoke(_context.Inject(new
        ProduceUnitCommandHeir()));
    }
}

}