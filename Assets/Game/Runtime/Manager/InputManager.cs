using UnityEngine;

namespace Game
{
    internal sealed class InputManager : MonoBehaviour
    {
        private KeyCode[] m_KeyCodeValues = new KeyCode[] { KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5 };

        private bool m_ProtagonistCanDoActions = true;

        private const string kHorizontalAxis = "Horizontal";
        private const string kVertcialAxis = "Vertical";
        private const string kSubmitButton = "Submit";
        private const string kCancelButton = "Cancel";

        internal Vector2 GetInputAxis()
        {
            return new Vector2(Input.GetAxisRaw(kHorizontalAxis), Input.GetAxisRaw(kVertcialAxis));
        }

        internal bool SubmitButtonPressThisFrame()
        {
            return Input.GetButtonDown(kSubmitButton);
        }

        internal bool CancelButtonPressedThisFrame()
        {
            return Input.GetButtonDown(kCancelButton);
        }

        internal bool NumberKeyPressedThisFrame(out int key)
        {
            key = int.MinValue;

            for (int i = 0; i < m_KeyCodeValues.Length; i++)
            {
                if (Input.GetKeyDown(m_KeyCodeValues[i]))
                {
                    key = i;
                    return true;
                }
            }

            return false;
        }

        internal bool CanProtagonistCanDoActions()
        {
            return m_ProtagonistCanDoActions;
        }

        internal void SetProtagonistFlagTrue()
        {
            m_ProtagonistCanDoActions = true;
        }

        internal void SetProtagonistFlagFalse()
        {
            m_ProtagonistCanDoActions = false;
        }
    }
}
