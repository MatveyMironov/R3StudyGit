using HealingSystem;
using HealthSystem;
using R3;
using UnityEngine;

namespace Core
{
    public class BootstrapperMB : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] private int maxHealthPoints;
        [SerializeField] private int startHealthPoints;
        [SerializeField] private HealthDisplayerMB healthDisplayer;

        [Header("Healing")]
        [SerializeField] private int startHealingItems;
        [SerializeField] private HealingInventoryDisplayerMB healingInventoryDisplayer;
        [SerializeField] private int maxRestoredHealthPoints;
        [SerializeField] private HealingDisplayerMB healingDisplayer;

        private CompositeDisposable _disposable;

        private void Start()
        {
            _disposable = new();

            Health health = new();
            health.MaxHealthPoints.Value = maxHealthPoints;
            health.ChangeHealthPoints(startHealthPoints);
            healthDisplayer.DisplayHealth(health);

            HealingInventory inventory = new();
            inventory.HealingItems.Value = startHealingItems;
            healingInventoryDisplayer.DisplayHealingInventory(inventory);

            Healing healing = new(health, inventory);
            healing.MaxRestoredHealthPoints.Value = maxRestoredHealthPoints;
            healingDisplayer.DisplayHealing(healing);
            _disposable.Add(healing);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}