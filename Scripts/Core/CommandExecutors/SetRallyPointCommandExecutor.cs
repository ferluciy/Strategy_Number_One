using Strategy;
using System.Threading.Tasks;
public class SetRallyPointCommandExecutor :
CommandExecutorBase<ISetRallyPointCommand>
{
    public override void ExecuteSpecificCommand(ISetRallyPointCommand
    command)
    {
    GetComponent<MainBuilding>().RallyPoint = command.RallyPoint;
    }
}