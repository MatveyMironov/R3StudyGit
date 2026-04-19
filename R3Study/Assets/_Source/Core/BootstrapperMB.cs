using HealthSystem;
using UnityEngine;

namespace Core
{
    public class BootstrapperMB : MonoBehaviour
    {
        [SerializeField] private HealthDisplayerMB healthDisplayer;

        private void Start()
        {
            HealthController healthController = new();
            healthDisplayer.DisplayHealth(healthController);

            healthController.MaxHealthPoints.Value = 100;
            healthController.ChangeHealthPoints(500);
        }
    }
}