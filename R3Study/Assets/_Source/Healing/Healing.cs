using HealthSystem;
using R3;
using System;
using UnityEngine;

namespace HealingSystem
{
    public class Healing : IDisposable
    {
        private readonly HealthController _health;
        private readonly HealingInventory _inventory;

        private readonly ReactiveProperty<bool> _isAbleToHeal = new();

        private readonly CompositeDisposable _subscriptions = new();

        public Healing(HealthController health, HealingInventory inventory)
        {
            _health = health ?? throw new System.ArgumentNullException(nameof(health));
            _inventory = inventory ?? throw new System.ArgumentNullException(nameof(inventory));

            IDisposable healthPointsSubscription = _health.HealthPoints.Subscribe(_ => SetIsAbleToHeal());
            _subscriptions.Add(healthPointsSubscription);
            IDisposable healingItemsSubscription = _inventory.HealingItems.Subscribe(_ => SetIsAbleToHeal());
            _subscriptions.Add(healingItemsSubscription);
        }

        public ReactiveProperty<int> MaxRestoredHealthPoints { get; } = new();
        public ReadOnlyReactiveProperty<bool> IsAbleToHeal => _isAbleToHeal;

        public bool TryHeal()
        {
            if (!_isAbleToHeal.CurrentValue) { return false; }

            _inventory.HealingItems.Value -= 1;
            _health.ChangeHealthPoints(MaxRestoredHealthPoints.CurrentValue);
            return true;
        }

        public void Dispose()
        {
            _subscriptions.Dispose();
        }

        private void SetIsAbleToHeal()
        {
            if (_health.HealthPoints.CurrentValue >= _health.MaxHealthPoints.CurrentValue
                || _inventory.HealingItems.CurrentValue <= 0)
            {
                if (_isAbleToHeal.CurrentValue == false) { return; }

                _isAbleToHeal.Value = false;
                return;
            }

            if (_isAbleToHeal.CurrentValue == true) { return; }

            _isAbleToHeal.Value = true;
        }
    }
}