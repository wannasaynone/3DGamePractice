using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShooterGame
{
    [CreateAssetMenu(menuName = "Data/Input/Keyboard")]
    public class KeyBoardInput : InputBase
    {
        [Range(0f, 1f)]
        [SerializeField] private float m_increaseSpeed = 0.25f;
        [Range(0f, 1f)]
        [SerializeField] private float m_backZeroSpeed = 1f;

        protected override void OnTick()
        {
            if (Input.GetKey(KeyCode.W))
            {
                Z = Mathf.Lerp(Z, 1f, m_increaseSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Z = Mathf.Lerp(Z, -1f, m_increaseSpeed);
            }
            else
            {
                Z = Mathf.Lerp(Z, 0, m_backZeroSpeed);
            }

            if (Input.GetKey(KeyCode.A))
            {
                X = Mathf.Lerp(X, -1f, m_increaseSpeed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                X = Mathf.Lerp(X, 1f, m_increaseSpeed);
            }
            else
            {
                X = Mathf.Lerp(X, 0f, m_backZeroSpeed);
            }
        }
    }
}
