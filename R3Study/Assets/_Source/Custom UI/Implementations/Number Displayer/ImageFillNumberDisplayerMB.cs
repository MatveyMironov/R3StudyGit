using UnityEngine;
using UnityEngine.UI;

namespace CustomUISystem.Implementations
{
    public class ImageFillNumberDisplayerMB : ANumberDisplayerMB
    {
        [SerializeField] private Image filledImage;

        private void Awake()
        {
            filledImage.type = Image.Type.Filled;
        }

        public override void DisplayNumber(float number)
        {
            filledImage.fillAmount = number;
        }
    }
}