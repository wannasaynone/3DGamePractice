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

        public float CurrentMoveSpeed { get; private set; }

        [SerializeField] private DefaultCharacterData m_defaultCharacterData = null;

        private Transform m_transform = null;
        private Rigidbody m_rigidbody = null;
        private Collider m_collider = null;
        private Animator m_aniamtor = null;

        private float m_speed = 0f;

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
    }
}
