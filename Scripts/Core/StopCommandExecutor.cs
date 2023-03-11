
using Abstractions.Commands;
using System.Threading;


namespace Strategy
{

    public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
    {

        public CancellationTokenSource CancellationTokenSource { get; set; }
        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            CancellationTokenSource?.Cancel();
        }

    }

}

