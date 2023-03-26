using Strategy;
using System.Threading.Tasks;
public class SetRallyPointCommandExecutor :
CommandExecutorBase<ISetRallyPointCommand>
{
    public override void ExecuteSpecificCommand(ISetRallyPointCommand
    command)
    {
        if (GetComponent<MainBuilding>() != null)
    GetComponent<MainBuilding>().RallyPoint = command.RallyPoint;
        if (GetComponent<ArcheryBuilding>() != null)
            GetComponent<ArcheryBuilding>().RallyPoint = command.RallyPoint;
    }
}