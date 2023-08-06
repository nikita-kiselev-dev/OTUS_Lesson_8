using Homework.Common;
using UnityEngine;

namespace Homework.Sound
{
    public class Bark : Sound
    {
        public Bark(MonoBehaviour owner) : base(owner)
        {
        }


        public override void Execute()
        {
            Debug.Log("Bark!");
        }

        public override void Execute(MoodStates.MoodState currentMood)
        {
            Debug.Log($"{currentMood} bark!");
        }
    }
}