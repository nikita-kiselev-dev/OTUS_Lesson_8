using UnityEngine;

namespace Homework.Movement
{
    public abstract class Move
    {
        protected MonoBehaviour Owner;

        protected Move(MonoBehaviour owner)
        {
            Owner = owner;
        }
        
        protected MoveDirection currentDirection = MoveDirection.Forward;
        protected MoveDirection newDirection = MoveDirection.Forward;

        public MoveDirection CurrentDirection => currentDirection;
        public MoveDirection NewDirection => newDirection;
        
        public enum MoveDirection
        {
            Backward = -1,
            NoDirection = 0,
            Forward = 1
        }
        
        public abstract void Execute();
        public abstract void UpdateDirection();
    }
}