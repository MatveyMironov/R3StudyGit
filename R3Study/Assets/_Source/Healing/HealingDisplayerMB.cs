using CustomUISystem;
using R3;
using System;
using UnityEngine;

namespace HealingSystem
{
    public class HealingDisplayerMB : MonoBehaviour
    {
        [SerializeField] private ANumberDisplayerMB maxRestoredHealthPointsDisplayer;

        private Healing _displayedHealing;
        private CompositeDisposable _subscriptions;

        private void OnDestroy()
        {
            HideHealing();
        }

        public void DisplayHealing(Healing healing)
        {
            HideHealing();
            _displayedHealing = healing;

            _subscriptions = new();
            IDisposable maxRestoredHealthPointsSubscription = healing.MaxRestoredHealthPoints.Subscribe(DisplayMaxRestoredHealthPoints);
            _subscriptions.Add(maxRestoredHealthPointsSubscription);
            IDisposable isAbleToHealSubscription = healing.IsAbleToHeal.Subscribe(DisplayIsAbleToHeal);
            _subscriptions.Add(isAbleToHealSubscription);
        }

        public void HideHealing()
        {
            _subscriptions?.Dispose();
            _displayedHealing = null;
        }

        public void Heal()
        {
            if (_displayedHealing == null) { return; }

            _displayedHealing.TryHeal();
        }

        private void DisplayMaxRestoredHealthPoints(int points)
        {
            maxRestoredHealthPointsDisplayer.DisplayNumber(points);
        }

        private void DisplayIsAbleToHeal(bool isAble)
        {
            gameObject.SetActive(isAble);
        }
    }
}