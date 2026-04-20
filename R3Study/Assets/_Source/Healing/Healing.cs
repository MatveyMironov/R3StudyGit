using StatSystem;
using InventorySystem;
using R3;
using System;
using UnityEngine;

namespace HealingSystem
{
    public class Healing : IDisposable
    {
        private readonly Stat _health;
        private readonly ItemInventory _healingItemInventory;

        private readonly ReactiveProperty<bool> _isAbleToHeal = new();

        private readonly CompositeDisposable _subscriptions = new();

        public Healing(Stat health, ItemInventory healingItemInventory)
        {
            _health = health ?? throw new System.ArgumentNullException(nameof(health));
            _healingItemInventory = healingItemInventory ?? throw new System.ArgumentNullException(nameof(healingItemInventory));

            IDisposable healthPointsSubscription = _health.StatPoints.Subscribe(_ => SetIsAbleToHeal());
            _subscriptions.Add(healthPointsSubscription);
            IDisposable healingItemsSubscription = _healingItemInventory.ItemCount.Subscribe(_ => SetIsAbleToHeal());
            _subscriptions.Add(healingItemsSubscription);
        }

        public ReactiveProperty<int> MaxRestoredHealthPoints { get; } = new();
        public ReadOnlyReactiveProperty<bool> IsAbleToHeal => _isAbleToHeal;

        public bool TryHeal()
        {
            if (!_isAbleToHeal.CurrentValue) { return false; }
            if (!_healingItemInventory.TryChangeItemCount(-1)) { return false; }

            _health.ChangeStatPoints(MaxRestoredHealthPoints.CurrentValue);
            return true;
        }

        public void Dispose()
        {
            _subscriptions.Dispose();
        }

        private void SetIsAbleToHeal()
        {
            if (_health.StatPoints.CurrentValue >= _health.MaxStatPoints.CurrentValue
                || _healingItemInventory.ItemCount.CurrentValue <= 0)
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