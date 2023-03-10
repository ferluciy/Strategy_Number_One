using Abstractions;
using System;
using UnityEngine;
using Zenject;

namespace Strategy
{
    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" +
nameof(AttackableValue), order = 0)]
    public class AttackableValue : ScriptableObjectValueBase<IAttackable>
    {

    }
}