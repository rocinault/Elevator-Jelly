using UnityEngine;

namespace Game
{
    internal sealed class SelectFloorQuest : Quest
	{
		[SerializeField]
		private Keypad m_Keypad;

        private void Start()
        {
            m_Keypad.OnKeypadFloorSelectedEvent += OnKeypadFloorSelected;
        }

        private void OnKeypadFloorSelected()
        {
            Debug.Log($"{gameObject.name} quest completed");

            OnQuestCompletedEvent?.Invoke(this);
        }

        private void OnDestroy()
        {
            m_Keypad.OnKeypadFloorSelectedEvent -= OnKeypadFloorSelected;
        }
    }
}
