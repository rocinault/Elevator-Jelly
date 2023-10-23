using UnityEngine;

namespace Game
{
    internal delegate void KeypadFloorSelectedEvent();

    internal sealed class Keypad : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private InputManager m_InputManager;

        [SerializeField]
        private Floor m_Floor;

        [SerializeField]
        private KeypadPanel m_KeypadPanel;

        internal KeypadFloorSelectedEvent OnKeypadFloorSelectedEvent;

        private bool m_IsInteracting;
        private bool m_IsInteractable;

        private void Start()
        {
            m_IsInteractable = true;
        }

        private void Update()
        {
            if (!m_IsInteracting) return;

            if (m_InputManager.CancelButtonPressedThisFrame())
            {
                CloseKeypad();
            }

            if (m_InputManager.NumberKeyPressedThisFrame(out int key))
            {
                Debug.Log(key);

                if (key == m_Floor.target)
                {
                    OnKeypadFloorSelectedEvent?.Invoke();

                    CloseKeypad();
                }
            }
        }

        public void OnInteract()
        {
            if (m_IsInteractable)
            {
                if (!m_IsInteracting)
                {
                    OpenKeypad();
                }
            } 
        }

        private void OpenKeypad()
        {
            m_IsInteracting = true;

            m_InputManager.SetProtagonistFlagFalse();

            m_KeypadPanel.Show();
        }

        private void CloseKeypad()
        {
            m_IsInteracting = false;

            m_InputManager.SetProtagonistFlagTrue();

            m_KeypadPanel.Hide();
        }
    }
}
