using UnityEngine;

namespace CustomUISystem.Implementations
{
    public class FirstNumberDisplayerMB : ANumberDisplayerMB
    {
        [SerializeField] private ATwoNumbersDisplayerMB twoNumbersDisplayer;

        public override void DisplayNumber(float number)
        {
            twoNumbersDisplayer.DisplayFirstNumber(number);
        }
    }
}