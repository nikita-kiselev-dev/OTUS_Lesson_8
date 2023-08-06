using Homework.Common;
using UnityEngine;

namespace Homework.Sound
{
    public abstract class Sound
    {
        protected MonoBehaviour Owner;

        protected Sound(MonoBehaviour owner)
        {
            Owner = owner;
        }

        public abstract void Execute();
        public abstract void Execute(MoodStates.MoodState currentMood);
    }
}