using CustomUISystem;
using R3;
using System;
using UnityEngine;

namespace HealthSystem
{
    public class HealthDisplayerMB : MonoBehaviour
    {
        [SerializeField] private ANumberDisplayerMB healthPointsDisplayer;
        [SerializeField] private ANumberDisplayerMB maxHealthPointsDisplayer;

        private Health _displayedHealth;
        private CompositeDisposable _subscriptions;

        private void OnDestroy()
        {
            HideHealth();
        }

        public void DisplayHealth(Health health)
        {
            HideHealth();
            _displayedHealth = health;

            _subscriptions = new();
            IDisposable healthPointSubscription = health.HealthPoints.Subscribe(DisplayHealthPoints);
            _subscriptions.Add(healthPointSubscription);
            IDisposable maxHealthPointsSubscription = health.MaxHealthPoints.Subscribe(DisplayMaxHealthPoints);
        }

        public void HideHealth()
        {
            _subscriptions?.Dispose();
            _displayedHealth = null;
        }

        public void ChangeHealthPoints(int delta)
        {
            if (_displayedHealth == null) { return; }

            _displayedHealth.ChangeHealthPoints(delta);
        }

        private void DisplayHealthPoints(int healthPoints)
        {
            healthPointsDisplayer.DisplayNumber(healthPoints);
        }

        private void DisplayMaxHealthPoints(int healthPoints)
        {
            maxHealthPointsDisplayer.DisplayNumber(healthPoints);
        }
    }
}