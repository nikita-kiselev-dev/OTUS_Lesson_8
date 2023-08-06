using UnityEngine;

namespace Homework.Movement
{
    public class Walk : Move
    {
        private readonly float _minX;
        private readonly float _maxX;
        private readonly float _speed;

        public Walk(MonoBehaviour owner) : base(owner)
        {
        }

        public Walk(MonoBehaviour owner, float minX, float maxX, float speed) : base(owner)
        {
            _minX = minX;
            _maxX = maxX;
            _speed = speed;
        }

        public override void Execute()
        {
            var newPosition = Owner.transform.position;
            newPosition.x += (int)currentDirection * Time.deltaTime * _speed;

            Owner.transform.position = newPosition;

            if (newPosition.x > _maxX)
            {
                currentDirection = MoveDirection.Backward;
            }
            else if (newPosition.x < _minX)
            {
                currentDirection = MoveDirection.Forward;
            }
        }

        public override void UpdateDirection()
        {
            newDirection = currentDirection;
        }
    }
}