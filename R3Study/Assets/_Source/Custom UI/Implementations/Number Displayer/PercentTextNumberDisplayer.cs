using System;
using TMPro;
using UnityEngine;

namespace CustomUISystem.Implementations
{
    public class PercentTextNumberDisplayer : ANumberDisplayerMB
    {
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private string textBefore;
        [SerializeField] private string textAfter;
        [SerializeField] private int decimalDigits;

        public override void DisplayNumber(float number)
        {
            number *= 100.0f;
            number = MathF.Round(number, decimalDigits);
            valueText.text = $"{textBefore}{number}{textAfter}";
        }
    }
}