using System;
using TMPro;
using UnityEngine;

namespace CustomUISystem.Implementations
{
    public class TextNumberDisplayerMB : ANumberDisplayerMB
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private int decimalDigits;

        public override void DisplayNumber(float number)
        {
            string letter = string.Empty;

            if (number / 1000 >= 1.0f)
            {
                number /= 1000;
                letter = "K";

                if (number / 1000 >= 1.0f)
                {
                    number /= 1000;
                    letter = "M";

                    if (number / 1000 >= 1.0f)
                    {
                        number /= 1000;
                        letter = "B";
                    }
                }
            }

            number = MathF.Round(number, decimalDigits);
            text.text = $"{number}{letter}";
        }
    }
}