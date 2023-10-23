using UnityEngine;

namespace Game
{
    internal sealed class CutsceneManager : MonoBehaviour
	{
		[SerializeField]
		private Cutscene m_StartCutscene;

		[SerializeField]
		private Cutscene m_CompleteCutscene;

		[SerializeField]
		private bool m_PlayOnStart;

        private void Start()
        {
			if (m_PlayOnStart)
			{
				StartCoroutine(DelayBeforeStart());
			}
        }

		private System.Collections.IEnumerator DelayBeforeStart()
		{
			yield return new WaitForSeconds(1f);

            OnSceneStart();
        }

        internal void OnSceneStart()
		{
			PlayCutscene(m_StartCutscene);
		}

		internal void OnSceneCompleted()
		{
			PlayCutscene(m_CompleteCutscene);
		}

		internal void PlayCutscene(Cutscene cutscene)
		{
			if (cutscene != null)
			{
				cutscene.OnCutsceneFinishedEvent += OnCutsceneFinished;
				cutscene.gameObject.SetActive(true);
			}
		}

		private void OnCutsceneFinished(Cutscene cutscene)
		{
            cutscene.gameObject.SetActive(false);
        }
	}
}
