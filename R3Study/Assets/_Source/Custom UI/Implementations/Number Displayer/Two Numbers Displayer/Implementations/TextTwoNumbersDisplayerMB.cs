using TMPro;
using UnityEngine;

namespace CustomUISystem.Implementations
{
    public class TextTwoNumbersDisplayerMB : ATwoNumbersDisplayerMB
    {
        [SerializeField] private TextMeshProUGUI twoNumbersText;

        private float _firstNumber;
        private float _secondNumber;

        public override void DisplayFirstNumber(float number)
        {
            _firstNumber = number;
            DisplayTwoNumbers();
        }

        public override void DisplaySecondNumber(float number)
        {
            _secondNumber = number;
            DisplayTwoNumbers();
        }

        private void DisplayTwoNumbers()
        {
            twoNumbersText.text = $"{_firstNumber}/{_secondNumber}";
        }
    }
}