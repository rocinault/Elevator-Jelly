using UnityEngine; 
using Golem;

namespace Game
{

    internal sealed class GameCoordinator : Singleton<GameCoordinator>
	{
        private void Start()
        {
            LoadSceneActOne();
        }

        public void LoadScene(int index)
        {
            StartCoroutine(LoadSceneAsync(index));
        }

        private System.Collections.IEnumerator LoadSceneAsync(int index)
        {
            yield return SceneManagerUtility.UnloadSceneAsync($"Act {index - 1}");
            yield return SceneManagerUtility.LoadSceneAsync($"Act {index}");
        }

        public void LoadSceneActOne()
        {
            StartCoroutine(LoadSceneActOneAsync());
        }

        private System.Collections.IEnumerator LoadSceneActOneAsync()
        {
            yield return SceneManagerUtility.LoadSceneAsync("Act 1");
        }

    }
}
