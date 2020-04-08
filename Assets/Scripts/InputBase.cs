using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShooterGame
{
    public abstract class InputBase : ScriptableObject
    {
        public float MoveX { get; protected set; }
        public float MoveZ { get; protected set; }
        public float MouseX { get; protected set; }
        public float MouseY { get; protected set; }

        public void Tick()
        {
            OnTick();
        }
        protected abstract void OnTick();
    }
}
