using UnityEngine;
using KahaGameCore.Interface;

namespace ShooterGame
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(Animator))]
    public class Character : View
    {
        public struct MoveVector
        {
            public float x;
            public float z;

            public MoveVector(float x, float z)
            {
                this.x = x;
                this.z = z;
            }
        }

        public enum State
        {
            Idle,
            Moving
        }

        public State CurrentState { get; private set; }
        public float CurrentMoveSpeed { get; private set; }

        [SerializeField] private DefaultCharacterData m_defaultCharacterData = null;

        private Transform m_transform = null;
        private Rigidbody m_rigidbody = null;
        private Collider m_collider = null;
        private Animator m_aniamtor = null;

        private float m_speed = 0f;

        private MoveVector m_currentMoveDirection = default;

        protected override void Awake()
        {
            base.Awake();
            m_rigidbody = GetComponent<Rigidbody>();
            m_collider = GetComponent<Collider>();
            m_aniamtor = GetComponent<Animator>();
            m_transform = transform;

            if(m_defaultCharacterData == null)
            {
                Debug.Log(new Debug.LogStruct
                {
                    className = "Character",
                    level = Debug.Level.Error,
                    message = "m_defaultCharacterData == null",
                    methodName = "Awake()"
                });
            }
            else
            {
                m_speed = m_defaultCharacterData.Speed;
            }
        }

        public void Move(MoveVector moveVector)
        {
            m_currentMoveDirection = moveVector;
            CurrentState = State.Moving;
        }

        public void StopMove()
        {
            CurrentState = State.Idle;
        }

        private void FixedUpdate()
        {
            switch(CurrentState)
            {
                case State.Idle:
                    {
                        break;
                    }
                case State.Moving:
                    {
                        m_rigidbody.MovePosition(transform.position + new Vector3(m_currentMoveDirection.x, 0f, m_currentMoveDirection.z).normalized * m_speed * Time.fixedDeltaTime);
                        break;
                    }
            }
        }    
    }
}
