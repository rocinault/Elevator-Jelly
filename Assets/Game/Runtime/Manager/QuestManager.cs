using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    internal delegate void OnAllQuestsCompleted();

	internal sealed class QuestManager : MonoBehaviour
	{
        [SerializeField, Range(1, 10)]
        private int m_ActToLoad;

        [SerializeField]
        private List<Quest> m_Quests = new List<Quest>();

        [SerializeField]
        private List<Quest> m_Completed = new List<Quest>();

        internal OnAllQuestsCompleted OnAllQuestsCompletedEvent;

        private void Start()
        {
            foreach (var quest in m_Quests)
            {
                quest.OnQuestCompletedEvent += OnQuestCompletedEvent;
            }
        }

        private void OnQuestCompletedEvent(Quest quest)
        {
            if (!m_Completed.Contains(quest))
            {
                m_Completed.Add(quest);

                if (m_Completed.Count == m_Quests.Count)
                {
                    Debug.Log("move on to next act!");

                    OnAllQuestsCompletedEvent?.Invoke();

                    StartCoroutine(DelayBeforeLoadingScene());
                }
            }
        }

        private System.Collections.IEnumerator DelayBeforeLoadingScene()
        {
            yield return new WaitForSeconds(2f);

            GameCoordinator.instance.LoadScene(m_ActToLoad);
        }

        private void OnDestroy()
        {
            foreach (var quest in m_Quests)
            {
                quest.OnQuestCompletedEvent -= OnQuestCompletedEvent;
            }
        }
    }
}
