using UnityEngine;
using UnityEngine.UI;

namespace CustomUISystem.Implementations
{
    public class SliderNumberDisplayer : ANumberDisplayerMB
    {
        [SerializeField] private Slider slider;

        public override void DisplayNumber(float number)
        {
            slider.value = number;
        }
    }
}