using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CustomUISystem.Implementations
{
    public class InputBindingsDisplayerMB : MonoBehaviour
    {
        [SerializeField] private InputActionReference inputAction;

        [Space]
        [SerializeField] private TextMeshProUGUI textUI;
        [SerializeField] private string textBefore;
        [SerializeField] private string textAfter;

        private void Start()
        {
            DisplayBindings();
        }

        [ContextMenu("Display Bindings")]
        public void DisplayBindings()
        {
            DisplayText(CreateBindingText(inputAction));
        }

        private string CreateBindingText(InputActionReference inputAction)
        {
            string bindingsString = "";

            bool hasPreviousBinding = false;

            foreach (var binding in inputAction.action.bindings)
            {
                if (hasPreviousBinding)
                {
                    if (!binding.isPartOfComposite)
                    {
                        bindingsString += " / ";
                    }
                }

                hasPreviousBinding = true;

                if (binding.isComposite) continue;

                bindingsString += $"[{binding.ToDisplayString()}]";
            }

            return bindingsString;
        }

        private void DisplayText(string text)
        {
            textUI.text = textBefore + text + textAfter;
        }
    }
}