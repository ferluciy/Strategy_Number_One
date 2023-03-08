using Abstractions.Commands;
using Abstractions;
using Strategy;
using System;
using System.Collections.Generic;
using UnityEngine;
using UtilsStrategy;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;
    [SerializeField] private AssetsContext _context;
    private ISelecatable _currentSelectable;
    private void Start()
    {
        _selectable.OnSelected += onSelected;
        onSelected(_selectable.CurrentValue);

    _view.OnClick += onButtonClick;
    }
    private void onSelected(ISelecatable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        _currentSelectable = selectable;
        _view.Clear();
        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as
            Component).GetComponentsInParent<ICommandExecutor>());
            _view.MakeLayout(commandExecutors);
        }
    }
    private void onButtonClick(ICommandExecutor commandExecutor)
    {
        var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
        var attackCommand = commandExecutor as CommandExecutorBase<IAttackCommand>;
        var moveCommand = commandExecutor as CommandExecutorBase<IMoveCommand>;
        var patrolCommand = commandExecutor as CommandExecutorBase<IPatrolCommand>;
        var stopCommand = commandExecutor as CommandExecutorBase<IStopCommand>;

        if (unitProducer != null)
        {
            unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
            return;
        }

        if (attackCommand != null)
        {
            attackCommand.ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
            return;
        }

        if (moveCommand != null)
        {
            moveCommand.ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
            return;
        }

        if (patrolCommand != null)
        {
            patrolCommand.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
            return;
        }

        if (stopCommand != null)
        {
            stopCommand.ExecuteSpecificCommand(_context.Inject(new StopCommand()));
            return;
        }

        throw new
        ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(onButtonClick)}:" +
        $"Unknown type of commands executor: { commandExecutor.GetType().FullName }!");
    }
}
