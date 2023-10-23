using UnityEngine;

namespace Game
{
	internal sealed class Character : MonoBehaviour, IInteractable
	{
		private Speak m_Speak;

        private void Awake()
        {
            m_Speak = GetComponentInChildren<Speak>();
        }

        public void OnInteract()
        {
            m_Speak.OnSpeak();
        }
    }
}
