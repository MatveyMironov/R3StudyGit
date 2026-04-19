using UnityEngine;

namespace CustomUISystem
{
    public abstract class ANumberDisplayerMB : MonoBehaviour, INumberDisplayer
    {
        public abstract void DisplayNumber(float number);
    }
}