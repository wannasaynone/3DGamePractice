using UnityEngine;

namespace ShooterGame
{
    public abstract class InputBase : ScriptableObject
    {
        public float MoveX { get; protected set; }
        public float MoveZ { get; protected set; }
        public float MouseX { get; protected set; }
        public float MouseY { get; protected set; }
        public bool IsAiming { get; protected set; }
        public bool StartFire { get; protected set; }
        public bool IsFiring { get; protected set; }
        public bool SwitchAimingSide { get; protected set; }

        public void Tick()
        {
            OnTick();
        }
        protected abstract void OnTick();
    }
}
