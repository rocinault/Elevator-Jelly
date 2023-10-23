using UnityEngine;
using UnityEngine.UI;
using Golem;

namespace Game
{
	internal sealed class CameraFade : Singleton<CameraFade>
	{
		[SerializeField]
		private Image m_Image;

        private readonly WaitForSeconds m_WaitForOneSecondDelay = new WaitForSeconds(kDuration);

        private const float kAlphaZero = 0f;
        private const float kAlphaOne = 1f;
        private const float kDuration = 2f;

		internal System.Collections.IEnumerator FadeIn()
		{
            m_Image.CrossFadeAlpha(kAlphaOne, kDuration, false);

            yield return m_WaitForOneSecondDelay;
        }

        internal System.Collections.IEnumerator FadeOut()
        {
            m_Image.CrossFadeAlpha(kAlphaZero, kDuration, false);

            yield return m_WaitForOneSecondDelay;
        }
    }
}
