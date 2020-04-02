using KahaGameCore.Interface;
using UnityEngine;

namespace ShooterGame
{
    public class ControllerBase : View
    {
        [SerializeField] private Character m_character = null;
        [SerializeField] private InputBase m_input = null;

        private void Update()
        {
            m_input.Tick();
            if(!Mathf.Approximately(m_input.X, 0f) || !Mathf.Approximately(m_input.Z, 0f))
            {
                m_character.Move(new Character.MoveVector(m_input.X, m_input.Z));
            }
            else
            {
                m_character.StopMove();
            }
        }
    }
}
