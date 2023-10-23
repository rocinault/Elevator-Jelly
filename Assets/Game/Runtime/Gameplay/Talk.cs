using UnityEngine;

namespace Game
{
	internal sealed class Talk : MonoBehaviour
	{
		[SerializeField]
		private InputManager m_InputManager;

		[SerializeField, Range(0.1f, 3f)]
		private float m_Radius;

		private const string kInteractableLayerMask = "Interactable";

        private void Update()
        {
			if (!m_InputManager.CanProtagonistCanDoActions()) return;

			if (m_InputManager.SubmitButtonPressThisFrame())
			{
				var result = Physics2D.OverlapCircle(transform.position, m_Radius, LayerMask.GetMask(kInteractableLayerMask));

				if (result != null && result.gameObject.TryGetComponent<IInteractable>(out var interactable))
				{
					interactable.OnInteract();
				}
			}
        }
    }
}
