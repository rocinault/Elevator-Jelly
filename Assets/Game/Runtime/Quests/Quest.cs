using UnityEngine;

namespace Game
{
    internal delegate void QuestCompletedEvent(Quest quest);

    internal abstract class Quest : MonoBehaviour
	{
        internal QuestCompletedEvent OnQuestCompletedEvent;
    }
}
