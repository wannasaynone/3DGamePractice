using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShooterGame
{
    public abstract class InputBase : ScriptableObject
    {
        public float X { get; protected set; }
        public float Z { get; protected set; }

        public void Tick()
        {
            OnTick();
        }
        protected abstract void OnTick();
    }
}
