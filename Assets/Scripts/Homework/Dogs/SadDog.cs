using Homework.Common;
using Homework.Movement;
using UnityEngine;

namespace Homework.Dogs
{
    /**
     * TODO:
     * 1. Реализовать этот тип по аналогии с HappyDog.
     * 2. Грустная собака должна перекрашиваться в оттенки синего.
     * 3. (сложно) Перенести метод GetSpriteRenderer в более подходящее место.
     */
    public class SadDog : Dog
    {
        private MoodStates.MoodState currentMood = MoodStates.MoodState.Sad;
        public override void ChangeColor()
        {
            var random = new System.Random();
            var blue = (float)random.NextDouble();
            GetSpriteRenderer().color = new Color(0.2f, 0.2f, 0.7f + blue / 2);
        }

        public override void SetMove()
        {
            Move = new Walk(this, -4, 4, 1);
        }

        public override void SetMood()
        {
            base.currentMood = currentMood;
        }
    }
}