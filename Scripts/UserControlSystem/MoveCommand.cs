
using Abstractions.Commands;
using UnityEngine;

namespace Strategy
{
    public class MoveCommand : IMoveCommand
    {
        public Vector3 Target { get; }
        public MoveCommand(Vector3 target)
        {
            Target = target;
        }

    }

}

