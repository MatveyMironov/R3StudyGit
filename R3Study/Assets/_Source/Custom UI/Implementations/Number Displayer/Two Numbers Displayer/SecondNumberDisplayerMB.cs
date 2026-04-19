using UnityEngine;

namespace CustomUISystem.Implementations
{
    public class SecondNumberDisplayerMB : ANumberDisplayerMB
    {
        [SerializeField] private ATwoNumbersDisplayerMB twoNumbersDisplayer;

        public override void DisplayNumber(float number)
        {
            twoNumbersDisplayer.DisplaySecondNumber(number);
        }
    }
}