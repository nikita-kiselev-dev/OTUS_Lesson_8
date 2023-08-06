using Homework.Common;
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
        public override void ChangeColor()
        {
            var random = new System.Random();
            var blue = (float)random.NextDouble();
            GetSpriteRenderer().color = new Color(0.2f, 0.2f, 0.7f + blue / 2);
        }

        public override void SetMood()
        {
            currentMood = MoodStates.MoodState.Sad;
        }
    }
}