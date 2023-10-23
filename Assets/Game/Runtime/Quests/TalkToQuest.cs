using UnityEngine;

namespace Game
{
	internal sealed class TalkToQuest : Quest
	{
        [SerializeField]
        private Cutscene m_Cutscene;

        private void Start()
        {
            m_Cutscene.OnCutsceneFinishedEvent += OnCutsceneFinished;
        }

        private void OnCutsceneFinished(Cutscene cutscene)
        {
            if (string.Equals(cutscene.gameObject.name, m_Cutscene.gameObject.name))
            {
                Debug.Log($"{gameObject.name} quest completed");

                OnQuestCompletedEvent?.Invoke(this);
            }
        }

        private void OnDestroy()
        {
            m_Cutscene.OnCutsceneFinishedEvent -= OnCutsceneFinished;
        }
    }
}
