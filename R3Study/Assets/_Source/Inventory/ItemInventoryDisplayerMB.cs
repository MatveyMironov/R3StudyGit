using CustomUISystem;
using R3;
using System;
using UnityEngine;

namespace InventorySystem
{
    public class ItemInventoryDisplayerMB : MonoBehaviour
    {
        [SerializeField] ANumberDisplayerMB itemCountDisplayer;

        private ItemInventory _displayedInventory;
        private IDisposable _subscription;

        public void DisplayItemInventory(ItemInventory inventory)
        {
            HideItemInventory();
            _displayedInventory = inventory;
            _subscription = inventory.ItemCount.Subscribe(DisplayItemCount);
        }

        public void HideItemInventory()
        {
            _subscription?.Dispose();
            _displayedInventory = null;
        }

        public void ChangeItemCount(int deltaCount)
        {
            _displayedInventory.TryChangeItemCount(deltaCount);
        }

        private void DisplayItemCount(int count)
        {
            itemCountDisplayer.DisplayNumber(count);
        }
    }
}