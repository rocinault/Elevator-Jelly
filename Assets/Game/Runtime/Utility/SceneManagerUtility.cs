using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    internal static class SceneManagerUtility
    {
        private static readonly List<string> s_LoadedScenes = new List<string>();

        internal static IEnumerator LoadSceneAsync(string name)
        {
            if (!s_LoadedScenes.Contains(name))
            {
                s_LoadedScenes.Add(name);

                yield return SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);

                yield return CameraFade.instance.FadeOut();

                yield return new WaitForSeconds(0.5f);
            }
        }

        internal static IEnumerator UnloadSceneAsync(string name)
        {
            if (s_LoadedScenes.Contains(name))
            {
                s_LoadedScenes.Remove(name);

                yield return new WaitForSeconds(0.5f);

                yield return CameraFade.instance.FadeIn();

                yield return SceneManager.UnloadSceneAsync(name);
            }
        }
    }
}
