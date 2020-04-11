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
            Cursor.lockState = CursorLockMode.Locked;

            MouseX = Input.GetAxis("Mouse X");
            MouseY = Input.GetAxis("Mouse Y");

            if (Input.GetKey(KeyCode.W))
            {
                MoveZ = Mathf.Lerp(MoveZ, 1f, m_increaseSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                MoveZ = Mathf.Lerp(MoveZ, -1f, m_increaseSpeed);
            }
            else
            {
                MoveZ = Mathf.Lerp(MoveZ, 0, m_backZeroSpeed);
            }

            if (Input.GetKey(KeyCode.A))
            {
                MoveX = Mathf.Lerp(MoveX, -1f, m_increaseSpeed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                MoveX = Mathf.Lerp(MoveX, 1f, m_increaseSpeed);
            }
            else
            {
                MoveX = Mathf.Lerp(MoveX, 0f, m_backZeroSpeed);
            }

            IsAiming = Input.GetMouseButton(1);
            IsMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

            if(IsAiming)
            {
                StartFire = Input.GetMouseButtonDown(0);
                IsFiring = Input.GetMouseButton(0);
            }

            SwitchAimingSide = Input.GetKeyDown(KeyCode.Space);
        }
    }
}
