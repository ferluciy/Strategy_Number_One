using Abstractions.Commands;
using UnityEngine;

namespace Strategy
{
    public class PatrolCommand : IPatrolCommand
    {
        public Vector3 StartPosition { get; }
        public Vector3 EndPosition { get; }
        public PatrolCommand(Vector3 startPos, Vector3 endPos)
        {
            StartPosition = startPos;
            EndPosition = endPos;
        }

    }

}


