using UnityEngine;
using Golem;
using Slowbro;

namespace Game
{
	internal sealed class CameraShake : MonoBehaviour
	{
        [SerializeField]
        private Keypad m_Keypad;

        [SerializeField]
        private QuestManager m_QuestManager;

        [SerializeField]
        private float m_Duration = 0.75f;

        private System.Collections.IEnumerator m_ElevatorShake;

        private Camera m_Camera;

        private void Awake()
        {
            m_Camera = Camera.main;
            m_ElevatorShake = Shake();
        }

        private void Start()
        {
            m_Keypad.OnKeypadFloorSelectedEvent += OnKeypadFloorSelected;
            m_QuestManager.OnAllQuestsCompletedEvent += Stop;
        }

        private void OnKeypadFloorSelected()
        {
            StartCoroutine(m_ElevatorShake);
        }

        internal void Stop()
        {
            StopCoroutine(m_ElevatorShake);
        }

        private System.Collections.IEnumerator Shake()
        {
            while (true)
            {
                yield return m_Camera.transform.Translate(Vector3.right * 0.025f, m_Duration, Space.Self, EasingType.PingPong);
                yield return m_Camera.transform.Translate(Vector3.left * 0.025f, m_Duration, Space.Self, EasingType.PingPong);
            }
        }

        private void OnDestroy()
        {
            m_Keypad.OnKeypadFloorSelectedEvent += OnKeypadFloorSelected;
            m_QuestManager.OnAllQuestsCompletedEvent -= Stop;
        }
    }
}
