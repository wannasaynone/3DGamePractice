﻿using UnityEngine;
using Cinemachine;

namespace ShooterGame
{
    public class PlayerController : ControllerBase
    {
        [Header("Follow Camera")]
        [SerializeField] private Transform m_followCameraRoot = null;
        [SerializeField] private CinemachineVirtualCamera m_camera_far = null;
        [SerializeField] private CinemachineVirtualCamera m_camera_aiming_right = null;
        [SerializeField] private CinemachineVirtualCamera m_camera_aiming_left = null;
        [SerializeField] private float m_rotateSpeed = 60f;
        [Header("Animator")]
        [SerializeField] private Animator m_animator = null;
        [SerializeField] private string m_layerName_aiming = "Aiming";
        [SerializeField] private string m_paraName_motionX = "motionX";
        [SerializeField] private string m_paraName_motionZ = "motionZ";
        [SerializeField] private string m_paraName_walk = "walk";
        [SerializeField] private string m_paraName_aimingRight = "aimingRight";

        private bool m_isAimingRight = false;

        private void FixedUpdate()
        {
            m_followCameraRoot.transform.position = Vector3.Lerp(m_followCameraRoot.transform.position, Character.transform.position, 0.35f);
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

            if (Input.IsAiming)
            {
                Vector3 _camDirProj_forward = Vector3.ProjectOnPlane(m_followCameraRoot.transform.forward, Vector3.up);

                Character.transform.rotation = Quaternion.Slerp(Character.transform.rotation, GameUtility.GetFacingDirection(_camDirProj_forward), 0.15f);
                m_animator.SetFloat(m_paraName_motionX, m_isAimingRight ? -Input.MoveX : Input.MoveX);
                m_animator.SetFloat(m_paraName_motionZ, Input.MoveZ);

                float _targetValue = Mathf.Abs(Input.MoveZ) > 0.1f && Mathf.Abs(Input.MoveX) > 0.1f ? 0f : 1f;
                m_animator.SetLayerWeight(m_animator.GetLayerIndex(m_layerName_aiming), Mathf.Lerp(m_animator.GetLayerWeight(m_animator.GetLayerIndex(m_layerName_aiming)), _targetValue, 0.5f));
            }
            else
            {
                Vector3 _camDirProj_forward = Vector3.ProjectOnPlane(m_followCameraRoot.transform.forward, Vector3.up);
                Vector3 _camDirProj_right = Vector3.ProjectOnPlane(m_followCameraRoot.transform.right, Vector3.up);

                Vector3 _moveDir = _camDirProj_right * Input.MoveX + _camDirProj_forward * Input.MoveZ;
                _moveDir.Normalize();

                Character.transform.rotation = Quaternion.Slerp(Character.transform.rotation, GameUtility.GetFacingDirection(_moveDir), 0.15f);
                m_animator.SetFloat(m_paraName_motionX, 0f);
                m_animator.SetFloat(m_paraName_motionZ, 1f);

                m_animator.SetLayerWeight(m_animator.GetLayerIndex(m_layerName_aiming), Mathf.Lerp(m_animator.GetLayerWeight(m_animator.GetLayerIndex(m_layerName_aiming)), 0f, 0.5f));
            }

            m_animator.SetBool(m_paraName_walk, Input.IsMoving);
        }

        protected override void OnInputTick()
        {
            if (Input.SwitchAimingSide)
            {
                m_isAimingRight = !m_isAimingRight;
                m_animator.SetBool(m_paraName_aimingRight, m_isAimingRight);
            }

            if (Input.IsAiming)
            {
                m_camera_far.Priority = 0;
            }
            else
            {
                m_camera_far.Priority = 20;
            }

            if (m_isAimingRight)
            {
                m_camera_aiming_right.Priority = 10;
                m_camera_aiming_left.Priority = 0;
            }
            else
            {
                m_camera_aiming_right.Priority = 0;
                m_camera_aiming_left.Priority = 10;
            }
        }
    }
}
