using Abstractions.Commands;
using Strategy;
using System;
using Zenject;

namespace Strategy { 
public class CommandButtonsModel
{
    public event Action<ICommandExecutor> OnCommandAccepted;
    public event Action OnCommandSent;
    public event Action OnCommandCancel;
    [Inject] private CommandCreatorBase<IProduceUnitCommand> _unitProducer;
        [Inject] private CommandCreatorBase<IProduceUnit2Command> _unit2Producer;
        [Inject] private CommandCreatorBase<ISetRallyPointCommand> _unitSetRally;
        [Inject] private CommandCreatorBase<IAttackCommand> _attacker;
    [Inject] private CommandCreatorBase<IStopCommand> _stopper;
    [Inject] private CommandCreatorBase<IMoveCommand> _mover;
    [Inject] private CommandCreatorBase<IPatrolCommand> _patroller;
private bool _commandIsPending;
    public void OnCommandButtonClicked(ICommandExecutor commandExecutor)
    {
        if (_commandIsPending)
        {
            processOnCancel();
        }
        _commandIsPending = true;
        OnCommandAccepted?.Invoke(commandExecutor);
        _unitProducer.ProcessCommandExecutor(commandExecutor, command =>
        executeCommandWrapper(commandExecutor, command));
            _unit2Producer.ProcessCommandExecutor(commandExecutor, command =>
        executeCommandWrapper(commandExecutor, command));
            _unitSetRally.ProcessCommandExecutor(commandExecutor, command =>
        executeCommandWrapper(commandExecutor, command));
            _attacker.ProcessCommandExecutor(commandExecutor, command =>
        executeCommandWrapper(commandExecutor, command));
        _stopper.ProcessCommandExecutor(commandExecutor, command =>
        executeCommandWrapper(commandExecutor, command));
        _mover.ProcessCommandExecutor(commandExecutor, command =>
        executeCommandWrapper(commandExecutor, command));
        _patroller.ProcessCommandExecutor(commandExecutor, command =>
        executeCommandWrapper(commandExecutor, command));
    }
    public void executeCommandWrapper(ICommandExecutor commandExecutor,
    object command)
    {
        commandExecutor.ExecuteCommand(command);
        _commandIsPending = false;
        OnCommandSent?.Invoke();
    }
    public void OnSelectionChanged()
    {
        _commandIsPending = false;
        processOnCancel();
    }
    private void processOnCancel()
    {
        _unitProducer.ProcessCancel();
            _unit2Producer.ProcessCancel();
            _unitSetRally.ProcessCancel();
            _attacker.ProcessCancel();
        _stopper.ProcessCancel();
        _mover.ProcessCancel();
        _patroller.ProcessCancel();
        OnCommandCancel?.Invoke();
    }
}
}