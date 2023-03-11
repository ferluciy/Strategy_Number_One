using Abstractions.Commands;
using UtilsStrategy;
using System;
using Zenject;
using UnityEngine;
using Abstractions;
using System.Threading;

namespace Strategy
{
    public class AttackCommandCreator :
    CancellableCommandCreatorBase<IAttackCommand, IAttackable>
    {
        protected override IAttackCommand createCommand(IAttackable argument) => new
        AttackCommand(argument);
    }
}