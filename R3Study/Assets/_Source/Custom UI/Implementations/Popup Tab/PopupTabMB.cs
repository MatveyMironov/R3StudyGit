using UnityEngine;
using UnityEngine.EventSystems;

namespace CustomUISystem.Implementations
{
    public class PopupTabMB : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private GameObject tabObject;

        private void Start()
        {
            HidePopupTab();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            ShowPopupTab();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            HidePopupTab();
        }

        private void ShowPopupTab()
        {
            tabObject.SetActive(true);
        }

        private void HidePopupTab()
        {
            tabObject.SetActive(false);
        }
    }
}