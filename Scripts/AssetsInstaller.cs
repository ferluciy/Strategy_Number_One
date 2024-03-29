using Abstractions;
using Strategy;
using System;
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
    [SerializeField] private Sprite _chomperSprite;
    [SerializeField] private Sprite _chomper2Sprite;
    public override void InstallBindings()
    {
        Container.BindInstances(_legacyContext, _groundClicksRMB,
        _attackableClicksRMB, _selectables);
        Container.Bind<IObservable<ISelectable>>().FromInstance(_selectables);
        Container.Bind<IAwaitable<IAttackable>>()
        .FromInstance(_attackableClicksRMB);
        Container.Bind<IAwaitable<Vector3>>()
        .FromInstance(_groundClicksRMB);

        Container.Bind<Sprite>().WithId("Unit1").FromInstance(_chomperSprite);
        Container.Bind<Sprite>().WithId("Unit2").FromInstance(_chomper2Sprite);
    }

}