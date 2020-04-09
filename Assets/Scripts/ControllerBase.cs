using KahaGameCore.Interface;
using UnityEngine;

namespace ShooterGame
{
    public abstract class ControllerBase : View
    {
        protected Character Character { get { return m_character; } }
        protected InputBase Input { get { return m_input; } }

        [SerializeField] private Character m_character = null;
        [SerializeField] private InputBase m_input = null;

        private void Update()
        {
            m_input.Tick();
            OnInputTick();
        }

        protected abstract void OnInputTick();
    }
}
