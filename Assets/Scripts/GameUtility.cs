using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShooterGame
{
    public static class GameUtility 
    {
        private static GameObject m_facingDirectionHelper = null;

        public static Quaternion GetFacingDirection(Vector3 direction)
        {
            if(m_facingDirectionHelper == null)
            {
                m_facingDirectionHelper = new GameObject("[FacingDirectionHelper]");
            }
            m_facingDirectionHelper.transform.position = Vector3.zero;
            m_facingDirectionHelper.transform.LookAt(m_facingDirectionHelper.transform.position + direction);

            return m_facingDirectionHelper.transform.rotation;
        }
    }
}
