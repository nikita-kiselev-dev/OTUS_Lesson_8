using Homework.Common;
using Homework.Movement;
using Homework.Sound;
using UnityEngine;

namespace Homework.Dogs
{
    /**
     * TODO:
     * 1. Добавить всем собакам способность гавкать: достаточно метода, пишущего в Unity-консоль строку с сообщение.
     * 2. HappyDog должен гавкать более радостно.
     * 3. (сложно) Пусть собаки гавкают только тогда, когда меняют направление движения.
     */
    public abstract class Dog : MonoBehaviour, IColorChangeable
    {
        public abstract void ChangeColor();
        public abstract void SetMove();
        public abstract void SetMood();

        private SpriteRenderer _spriteRenderer;

        protected MoodStates.MoodState currentMood = MoodStates.MoodState.Default;
        
        protected Move Move;
        protected Sound.Sound Sound;

        protected void Start()
        {
            SetMood();
            SetMove();
            
            Sound = new Bark(this);

            InputController.Instance.OnColorChanged += OnColorChanged;
        }

        protected void Update()
        {
            Move.Execute();
            TryMakeSound();
            Move.UpdateDirection();
        }

        private void TryMakeSound()
        {
            if (Move.CurrentDirection != Move.NewDirection)
            {
                Sound.Execute(currentMood);
            }
        }

        protected SpriteRenderer GetSpriteRenderer()
        {
            if (_spriteRenderer == null)
                _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            return _spriteRenderer;
        }
        
        private void OnDestroy()
        {
            InputController.Instance.OnColorChanged -= OnColorChanged;
        }

        private void OnColorChanged()
        {
            ChangeColor();
        }

    }
}