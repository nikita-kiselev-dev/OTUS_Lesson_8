using Homework.Common;
using Homework.Movement;
using UnityEngine;

namespace Homework.Dogs
{
    public class HappyDog : Dog
    {
        public override void ChangeColor()
        {
            var random = new System.Random();
            var red = (float)random.NextDouble();
            GetSpriteRenderer().color = new Color(0.5f + red / 2, 0.1f, 0.1f);
        }

        public override void SetMood()
        {
            currentMood = MoodStates.MoodState.Happy;
        }

        public override void SetMove()
        {
            Move = new Run(this, -4, 4, 1, Random.Range(0.3f, 2.5f));
        }
    }
}