using UnityEngine;

namespace ShooterGame
{
    [CreateAssetMenu(menuName = "Data/Default Character Data")]
    public class DefaultCharacterData : ScriptableObject
    {
        public float Speed { get { return m_speed; } }
        [SerializeField] private float m_speed = 0f;
    }
}
