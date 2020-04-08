using UnityEngine;
using Cinemachine;

namespace ShooterGame
{
    public class PlayerController : ControllerBase
    {
        [Header("Follow Camera")]
        [SerializeField] private Transform m_followCameraRoot = null;
        [SerializeField] private CinemachineVirtualCamera m_followCamera = null;
        [SerializeField] private float m_rotateSpeed = 60f;

        protected override void OnInputTick()
        {
            if (m_followCamera != null)
            {
                m_followCameraRoot.transform.position = Character.transform.position;
                m_followCameraRoot.transform.eulerAngles += new Vector3(0f, m_rotateSpeed * Input.MouseX, 0f) * Time.deltaTime;
                m_followCameraRoot.transform.eulerAngles += new Vector3(m_rotateSpeed * -Input.MouseY, 0f, 0f) * Time.deltaTime;
                if (m_followCameraRoot.transform.eulerAngles.x > 180f)
                {
                    m_followCameraRoot.transform.eulerAngles = new Vector3(0f, m_followCameraRoot.transform.eulerAngles.y, m_followCameraRoot.transform.eulerAngles.z);
                }
                else if (m_followCameraRoot.transform.eulerAngles.x > 20f)
                {
                    m_followCameraRoot.transform.eulerAngles = new Vector3(20f, m_followCameraRoot.transform.eulerAngles.y, m_followCameraRoot.transform.eulerAngles.z);
                }
            }

            if (!Mathf.Approximately(Input.MoveX, 0f) || !Mathf.Approximately(Input.MoveZ, 0f))
            {
                Vector3 _camDir = m_followCameraRoot.transform.right * Input.MoveX + m_followCameraRoot.transform.forward * Input.MoveZ;
                Character.Move(new Character.MoveVector(_camDir.x, _camDir.z));
            }
            else
            {
                Character.StopMove();
            }
        }
    }
}
