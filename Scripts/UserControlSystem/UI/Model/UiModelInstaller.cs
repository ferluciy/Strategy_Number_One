using Abstractions.Commands;
using System.ComponentModel;
using UnityEngine;
using UtilsStrategy;
using Zenject;

namespace Strategy { 
public class UiModelInstaller : MonoInstaller
{
[SerializeField] private AssetsContext _legacyContext;
 [SerializeField] private Vector3Value _groundClicks;
 [SerializeField] private AttackableValue _attackable;
        [SerializeField] private SelectableValue _selectable;
        public override void InstallBindings()
    {
        Container.Bind<AssetsContext>().FromInstance(_legacyContext);
            Container.Bind<Vector3Value>().FromInstance(_groundClicks);
            Container.Bind<AttackableValue>().FromInstance(_attackable);
            Container.Bind<SelectableValue>().FromInstance(_selectable);
            Container.Bind<CommandButtonsModel>().AsTransient();
            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
        .To<ProduceUnitCommandCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IAttackCommand>>()
        .To<AttackCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IMoveCommand>>()
        .To<MoveCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IPatrolCommand>>()
        .To<PatrolCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IStopCommand>>()
        .To<StopCommandCreator>().AsTransient();
        
    }
}

}