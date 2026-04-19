using HealingSystem;
using HealthSystem;
using R3;
using UnityEngine;

namespace Core
{
    public class BootstrapperMB : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] private HealthDisplayerMB healthDisplayer;
        [SerializeField] private int maxHealthPoints;
        [SerializeField] private int startHealthPoints;

        [Header("Healing")]
        [SerializeField] private int startHealingItems;
        [SerializeField] private HealingInventoryDisplayerMB healingInventoryDisplayer;
        [SerializeField] private int maxRestoredHealthPoints;
        [SerializeField] private HealingDisplayerMB healingDisplayer;

        private CompositeDisposable _disposable;

        private void Start()
        {
            _disposable = new();

            HealthController healthController = new();
            healthController.MaxHealthPoints.Value = maxHealthPoints;
            healthController.ChangeHealthPoints(startHealthPoints);
            healthDisplayer.DisplayHealth(healthController);

            HealingInventory inventory = new();
            inventory.HealingItems.Value = startHealingItems;
            healingInventoryDisplayer.DisplayHealingInventory(inventory);

            Healing healing = new(healthController, inventory);
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