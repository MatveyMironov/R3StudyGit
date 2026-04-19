using CustomUISystem;
using R3;
using System;
using UnityEngine;

namespace HealingSystem
{
    public class HealingInventoryDisplayerMB : MonoBehaviour
    {
        [SerializeField] ANumberDisplayerMB healingItemsDisplayer;

        private HealingInventory _displayedInventory;
        private IDisposable _subscription;

        public void DisplayHealingInventory(HealingInventory inventory)
        {
            HideHealingInventory();
            _displayedInventory = inventory;
            _subscription = inventory.HealingItems.Subscribe(DisplayHealingItems);
        }

        public void HideHealingInventory()
        {
            _subscription?.Dispose();
            _displayedInventory = null;
        }

        public void ChangeHealingItems(int delta)
        {
            if (_displayedInventory.HealingItems.CurrentValue + delta < 0)
            {
                _displayedInventory.HealingItems.Value = 0;
                return;
            }

            _displayedInventory.HealingItems.Value += delta;
        }

        private void DisplayHealingItems(int items)
        {
            healingItemsDisplayer.DisplayNumber(items);
        }
    }
}