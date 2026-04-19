using CustomUISystem;
using R3;
using UnityEngine;

namespace HealthSystem
{
    public class HealthDisplayerMB : MonoBehaviour
    {
        [SerializeField] private ANumberDisplayerMB healthPointsDisplayer;

        public HealthController DisplayedHealth { get; private set; }

        private void OnDestroy()
        {
            
        }

        public void DisplayHealth(HealthController health)
        {
            HideHealth();
            DisplayedHealth = health;

            health.HealthPoints.Subscribe(DisplayHealthPoints);
        }

        public void HideHealth()
        {
            if (DisplayedHealth == null) { return; }

            DisplayedHealth = null;
        }

        private void DisplayHealthPoints(int healthPoints)
        {
            healthPointsDisplayer.DisplayNumber(healthPoints);
        }
    }
}