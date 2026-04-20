using UnityEngine;

namespace CustomUISystem.Implementations
{
    public class DivideTwoNumbersDisplayerMB : ATwoNumbersDisplayerMB
    {
        [SerializeField] private ANumberDisplayerMB resultDisplayer;

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
            float result = _firstNumber / _secondNumber;
            resultDisplayer.DisplayNumber(result);
        }
    }
}