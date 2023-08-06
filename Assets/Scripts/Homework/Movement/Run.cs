using UnityEngine;

namespace Homework.Movement
{
    /**
     * TODO:
     * 1. Реализовать этот тип перемещения по аналогии с Walk, но отличающийся от него,
     * например, пусть перемещение будет по окружности заданного радиуса.
     * 2. Заменить передвижение у HappyDog и/или SadDog этим типом. Убедиться, что он работает.
     */
    public class Run : Move
    {
        private readonly float _minX;
        private readonly float _maxX;
        private readonly float _speed;

        private float _angle;
        private float _radius;
        
        public Run (MonoBehaviour owner) : base(owner)
        {
        }

        public Run (MonoBehaviour owner, float minX, float maxX, float speed, float radius) : base(owner)
        {
            _minX = minX;
            _maxX = maxX;
            _speed = speed;
            _radius = radius;
        }

        public override void Execute()
        {
            var newPosition = Owner.transform.position;

            _angle += Time.deltaTime;

            var x = Mathf.Cos (_angle * _speed * (int)currentDirection) * _radius;
            var y = Mathf.Sin (_angle * _speed * (int)currentDirection) * _radius;
            
            newPosition = new Vector2(x, y);
            
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