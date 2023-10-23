using UnityEngine;

namespace Golem
{
	public sealed class Stopwatch
	{
		public bool IsComplete => TimeElapsed > m_Duration;

		public float TimeElapsed => m_Time += Time.deltaTime;

		private float m_Duration;
		private float m_Time;

		public Stopwatch()
		{

		}

		public Stopwatch(float duration)
		{
			m_Duration = duration;
		}

		public void SetDuration(float duration)
		{
			m_Duration = duration;
		}

		public void SetRandomDuration(float minInclusive, float maxInclusive)
		{
			m_Duration = Random.Range(minInclusive, maxInclusive);
		}

		public void Reset()
		{
			m_Time = 0f;
		}
	}
}
