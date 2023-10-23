using UnityEngine;

namespace Game
{
    internal sealed class Elevator : MonoBehaviour
	{
		[SerializeField]
		private Keypad m_Keypad;

        [SerializeField]
        private QuestManager m_QuestManager;

        [SerializeField]
        private AudioManager m_AudioManager;

		[SerializeField]
		private Floor m_Floor;

        [SerializeField]
        private float m_Speed = 1f;

		private Animator m_Animator;

		private readonly int m_DownAnimation = Animator.StringToHash("Down");
		private readonly int m_UpAnimation = Animator.StringToHash("Up");
        private readonly int m_OpenAnimation = Animator.StringToHash("Open");
        //private readonly int m_CloseAnimation = Animator.StringToHash("Close");

        private void Awake()
        {
			m_Animator = GetComponent<Animator>();
        }

        private void Start()
        {
			m_Keypad.OnKeypadFloorSelectedEvent += OnKeypadFloorSelected;
            m_QuestManager.OnAllQuestsCompletedEvent += StopElevator;
        }

		private void OnKeypadFloorSelected()
		{
			MoveElevator();
		}

        internal void MoveElevator()
		{
            m_AudioManager.PlayElevatorSound();

            m_Animator.speed = m_Speed;

            if (m_Floor.target > m_Floor.level)
            {
                m_Animator.Play(m_UpAnimation);
            }
            else
            {
                m_Animator.Play(m_DownAnimation);
            }
        }

		internal void StopElevator()
		{
            m_AudioManager.StopElevatorSound();

            m_Animator.speed = 1f;
            m_Animator.Play(m_OpenAnimation);
		}

        private void OnDestroy()
        {
			m_Keypad.OnKeypadFloorSelectedEvent -= OnKeypadFloorSelected;
            m_QuestManager.OnAllQuestsCompletedEvent -= StopElevator;
        }
    }
}
