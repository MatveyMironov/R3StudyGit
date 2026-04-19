using R3;

namespace HealingSystem
{
    public class HealingInventory
    {
        public ReactiveProperty<int> HealingItems { get; } = new();
    }
}