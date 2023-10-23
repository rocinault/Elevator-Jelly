using UnityEngine;

namespace Game
{
	internal sealed class Protagonist : MonoBehaviour
	{
		[SerializeField]
		private InputManager m_InputManager;

		private Rigidbody2D m_Rigidbody2D;

		private Vector2 m_Input;
		private Vector2 m_Force;
		private Vector2 m_Velocity;

		private const float kMovementForce = 2.5f;
		private const float kMovementDamp = 4f;

        private void Awake()
        {
			m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!m_InputManager.CanProtagonistCanDoActions()) return;

            CaptureInputAndClampAxis();
        }

        private void CaptureInputAndClampAxis()
        {
			m_Input = m_InputManager.GetInputAxis();

            if (m_Input.x != 0f && m_Input.y != 0f)
            {
                m_Input.x = 0f;
            }
        }

        private void FixedUpdate()
        {
            CaptureRigidody2DVelocity();
            ResetAppliedForcesToZero();

            m_Force += (m_Input * kMovementForce - m_Velocity) / kMovementDamp;

            m_Rigidbody2D.AddForce(m_Force, ForceMode2D.Impulse);
        }

        private void CaptureRigidody2DVelocity()
        {
            m_Velocity = m_Rigidbody2D.velocity;
        }

        private void ResetAppliedForcesToZero()
        {
            m_Force = Vector2.zero;
        }
    }
}
