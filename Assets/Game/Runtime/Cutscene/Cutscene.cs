using UnityEngine;

namespace Game
{
    internal delegate void CutsceneFinishedEvent(Cutscene cutscene);

	internal sealed class Cutscene : MonoBehaviour
	{
		[SerializeField]
		private InputManager m_InputManager;

		[SerializeField]
		private DialogueManager m_DialogueManager;

		[SerializeField]
		private Dialogue m_Dialogue;

        internal CutsceneFinishedEvent OnCutsceneFinishedEvent;

        private int m_Index;
        private int m_Length;

        private void OnEnable()
        {
            m_Index = 0;
            m_Length = m_Dialogue.converstaions.Length;

            m_InputManager.SetProtagonistFlagFalse();
            m_DialogueManager.ShowPanel();

            var conversation = m_Dialogue.converstaions[m_Index];

            m_DialogueManager.SetSpeaker(conversation.name);
            m_DialogueManager.SetAudioBlip(conversation.clip);
            m_DialogueManager.SetDialogue(conversation.sentence);
        }

        private void Update()
        {
			if (m_InputManager.SubmitButtonPressThisFrame())
			{
                m_Index++;

                if (IsIndexLessThanDialogueLength())
                {
                    Resume();
                }
                else
                {
                    Exit();
                }
			}
        }

        private bool IsIndexLessThanDialogueLength()
        {
            return m_Index < m_Length;
        }

        private void Resume()
        {
            var conversation = m_Dialogue.converstaions[m_Index];

            m_DialogueManager.SetSpeaker(conversation.name);
            m_DialogueManager.SetAudioBlip(conversation.clip);
            m_DialogueManager.SetDialogue(conversation.sentence);
        }

        private void Exit()
        {
            m_DialogueManager.SetSpeaker(string.Empty);
            m_DialogueManager.SetDialogue(string.Empty);

            m_DialogueManager.HidePanel();
            m_InputManager.SetProtagonistFlagTrue();

            OnCutsceneFinishedEvent?.Invoke(this);
        }

        private void OnDisable()
        {
            
        }
	}
}
