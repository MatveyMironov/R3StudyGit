using UnityEngine;
using UnityEngine.InputSystem;

namespace CustomUISystem.Implementations
{
    [RequireComponent(typeof(RectTransform))]
    public class CursorFollowingTabMB : MonoBehaviour
    {
        [SerializeField] private RectTransform canvas;

        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            Vector2 targetPosition = Mouse.current.position.ReadValue();

            targetPosition.x = Mathf.Clamp(targetPosition.x, 0, canvas.rect.width - _rectTransform.rect.width);
            targetPosition.y = Mathf.Clamp(targetPosition.y, 0, canvas.rect.height - _rectTransform.rect.height);

            _rectTransform.anchoredPosition = targetPosition;
        }
    }
}