using UnityEngine;

namespace Game
{
	internal sealed class AudioManager : MonoBehaviour
	{
		[SerializeField]
		private AudioSource m_ElevatorSource;

		[SerializeField]
		private AudioSource m_BlipSource;

		internal void PlayElevatorSound()
		{
			m_ElevatorSource.Play();
		}

		internal void StopElevatorSound()
		{
			m_ElevatorSource.Pause();
		}

		internal void PlayBlip(AudioClip clip)
		{
			m_BlipSource.PlayOneShot(clip);
		}
	}
}
