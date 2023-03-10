using Abstractions.Commands;
using UtilsStrategy;
using System;
using Zenject;

namespace Strategy
{
    public class StopCommandCreator : CommandCreatorBase<IStopCommand>
    {
        [Inject] private AssetsContext _context;
        protected override void
        classSpecificCommandCreation(Action<IStopCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new
            StopCommand()));
        }
    }

}

