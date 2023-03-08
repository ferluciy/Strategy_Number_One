using Abstractions.Commands;
using UnityEngine;

namespace Strategy { 
public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor
{
    public void ExecuteCommand(object command) =>
    ExecuteSpecificCommand((T)command);
    public abstract void ExecuteSpecificCommand(T command);
}
}