using Abstractions;
using Abstractions.Commands;

namespace Strategy
{
    public class AttackCommand : IAttackCommand
    {
        public IAttackable Target { get; }
        public AttackCommand(IAttackable target)
        {
            Target = target;
        }

    }

}
