using UnityEngine;

namespace CustomUISystem
{
    public abstract class ABoolDisplayerMB : MonoBehaviour, IBoolDisplayer
    {
        public abstract void DisplayBool(bool value);
    }
}