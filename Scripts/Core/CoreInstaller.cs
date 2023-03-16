using Strategy;
using System.ComponentModel;
using Zenject;

namespace Strategy { 
public class CoreInstaller : MonoInstaller
{
public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<TimeModel>().AsSingle();
    }
}

}