using UnityEngine;

namespace Game
{
	internal sealed class DialogueManager : MonoBehaviour
	{
		[SerializeField]
		private DialoguePanel m_DialoguePanel;

		internal void ShowPanel()
		{
			m_DialoguePanel.gameObject.SetActive(true);
		}

		internal void HidePanel()
		{
            m_DialoguePanel.gameObject.SetActive(false);
        }

		internal void SetSpeaker(string name)
		{
			m_DialoguePanel.SetSpeaker(name);
		}

		internal void SetAudioBlip(AudioClip clip)
		{
			m_DialoguePanel.SetAudioBlip(clip);
		}

		internal void SetDialogue(string message)
		{
			m_DialoguePanel.SetDialogue(message);
		}
	}
}
