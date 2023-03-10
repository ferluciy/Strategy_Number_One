using Abstractions;
using Strategy;
using UnityEngine;
using UtilsStrategy;
using Zenject;
[CreateAssetMenu(fileName = "AssetsInstaller", menuName = "Installers/AssetsInstaller")]
public class AssetsInstaller : ScriptableObjectInstaller<AssetsInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackableClicksRMB;
    [SerializeField] private SelectableValue _selectables;
    public override void InstallBindings()
    {
        Container.BindInstances(_legacyContext, _groundClicksRMB,
        _attackableClicksRMB, _selectables);
        Container.Bind<IAwaitable<IAttackable>>()
        .FromInstance(_attackableClicksRMB);
        Container.Bind<IAwaitable<Vector3>>()
        .FromInstance(_groundClicksRMB);
    }

}