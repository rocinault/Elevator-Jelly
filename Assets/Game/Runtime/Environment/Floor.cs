using UnityEngine;

namespace Game
{
	internal sealed class Floor : MonoBehaviour
	{
		[SerializeField, Range(0, 6)]
		internal int level;

        [SerializeField, Range(0, 6)]
        internal int target;
	}
}
