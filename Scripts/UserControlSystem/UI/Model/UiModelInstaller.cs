using Abstractions;
using Abstractions.Commands;
using System;
using System.ComponentModel;
using UnityEngine;
using UtilsStrategy;
using Zenject;

namespace Strategy { 
public class UiModelInstaller : MonoInstaller
{
        public override void InstallBindings()
    {

            Container.Bind<CommandButtonsModel>().AsTransient();
            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
        .To<ProduceUnitCommandCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IProduceUnit2Command>>()
        .To<ProduceUnit2CommandCommandCreator>().AsTransient();

            Container.Bind<CommandCreatorBase<ISetRallyPointCommand>>()
        .To<SetRallyPointCommandCreator>().AsTransient();

            Container.Bind<CommandCreatorBase<IAttackCommand>>()
        .To<AttackCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IMoveCommand>>()
        .To<MoveCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IPatrolCommand>>()
        .To<PatrolCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IStopCommand>>()
        .To<StopCommandCreator>().AsTransient();

            Container.Bind<BottomCenterModel>().AsTransient();

            Container.Bind<float>().WithId("Unit1").FromInstance(5f);
            Container.Bind<string>().WithId("Unit1").FromInstance("Unit1");
            Container.Bind<float>().WithId("Unit2").FromInstance(5f);
            Container.Bind<string>().WithId("Unit2").FromInstance("Unit2");

        }
}

}