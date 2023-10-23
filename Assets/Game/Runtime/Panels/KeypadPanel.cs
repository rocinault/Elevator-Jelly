using UnityEngine;

namespace Game
{
	internal sealed class KeypadPanel : MonoBehaviour
	{
		internal void Show()
		{
			gameObject.SetActive(true);
		}

		internal void Hide()
		{
            gameObject.SetActive(false);
        }
    }
}
