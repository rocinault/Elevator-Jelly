using System;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "dialogue", menuName = "ScriptableObjects/Elevator/Dialogue/Asset", order = 150)]
    internal sealed class Dialogue : ScriptableObject
	{
        [SerializeField]
        internal Converstaion[] converstaions;
    }

    [Serializable]
    internal sealed class Converstaion
    {
        [SerializeField]
        internal string name;

        [SerializeField]
        internal AudioClip clip;

        [SerializeField, TextArea]
        internal string sentence;
    }
}
