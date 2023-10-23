using UnityEngine;

namespace Game
{
	internal sealed class Speak : MonoBehaviour
	{
		[Header("Managers")]
		[SerializeField]
		private CutsceneManager m_CutsceneManager;

        [Header("Cutscene")]
        [SerializeField]
		private Cutscene m_CutsceneToPlay;

        [Header("Quests")]
        [SerializeField]
		private Quest m_UnlockedByQuest;

		[SerializeField]
		private bool m_IsUnlocked;

        private void Start()
        {
			if (m_UnlockedByQuest != null)
			{
				m_UnlockedByQuest.OnQuestCompletedEvent += OnQuestCompleted;
			}
        }

		private void OnQuestCompleted(Quest quest)
		{
			m_IsUnlocked = true;
		}

        internal void OnSpeak()
		{
			if (m_IsUnlocked)
			{
                m_CutsceneManager.PlayCutscene(m_CutsceneToPlay);
            }
		}

        private void OnDestroy()
        {
			if (m_UnlockedByQuest != null)
			{
				m_UnlockedByQuest.OnQuestCompletedEvent -= OnQuestCompleted;
			}
        }
    }
}
