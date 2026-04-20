using R3;

namespace InventorySystem
{
    public class ItemInventory
    {
        private readonly ReactiveProperty<int> _itemCount = new();
        public ReadOnlyReactiveProperty<int> ItemCount => _itemCount;

        public bool TryChangeItemCount(int deltaCount)
        {
            if (_itemCount.CurrentValue + deltaCount < 0) { return false; }

            _itemCount.Value += deltaCount;
            return true;
        }
    }
}