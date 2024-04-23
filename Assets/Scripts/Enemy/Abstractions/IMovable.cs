using UnityEngine;

namespace Enemy
{
    public interface IMovable
    {
        Transform Transform { get; }
        float Speed { get; }

        void SetMover(IMover mover);
    }
}