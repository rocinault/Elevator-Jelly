using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	internal sealed class DialoguePanel : MonoBehaviour
	{
		[SerializeField]
		private Text m_Speaker;

		[SerializeField]
		private Typewriter m_Dialogue;

		internal void SetSpeaker(string name)
		{
			m_Speaker.text = name;
		}

		internal void SetAudioBlip(AudioClip clip)
		{
			m_Dialogue.clip = clip;
		}

		internal void SetDialogue(string message)
		{
			m_Dialogue.PrintTextCharByChar(message);
		}
	}
}
