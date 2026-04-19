using UnityEngine;

namespace CustomUISystem.Implementations
{
    public class CompositeNumberDisplayerMB : ANumberDisplayerMB
    {
        [SerializeField] private ANumberDisplayerMB[] displayers = new ANumberDisplayerMB[0];

        public override void DisplayNumber(float number)
        {
            foreach (var displayer in displayers)
            {
                displayer.DisplayNumber(number);
            }
        }
    }
}