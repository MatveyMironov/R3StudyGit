using DeathSystem;
using HealingSystem;
using StatSystem;
using InventorySystem;
using R3;
using UnityEngine;

namespace Core
{
    public class BootstrapperMB : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] private int maxHealthPoints;
        [SerializeField] private int startHealthPoints;
        [SerializeField] private StatDisplayerMB healthDisplayer;

        [Header("Healing")]
        [SerializeField] private int startHealingItems;
        [SerializeField] private ItemInventoryDisplayerMB healingInventoryDisplayer;
        [SerializeField] private int maxRestoredHealthPoints;
        [SerializeField] private HealingDisplayerMB healingDisplayer;

        [Header("Mana")]
        [SerializeField] private int maxManaPoints;
        [SerializeField] private int startManaPoints;
        [SerializeField] private StatDisplayerMB manaDisplayer;
        [SerializeField] private int startManaPotions;
        [SerializeField] private ItemInventoryDisplayerMB manaPotionInventoryDisplayer;

        [Header("Coins")]
        [SerializeField] private int startCoins;
        [SerializeField] private ItemInventoryDisplayerMB coinInventoryDisplayer;

        [Header("Death")]
        [SerializeField] private GameObject deathPanel;
        [SerializeField] private GameObject warningTab;
        [SerializeField] private int criticalHealth;

        private CompositeDisposable _disposable;

        private void Start()
        {
            _disposable = new();

            Stat health = new();
            health.MaxStatPoints.Value = maxHealthPoints;
            health.ChangeStatPoints(startHealthPoints);
            healthDisplayer.DisplayStat(health);

            ItemInventory healingItemInventory = new();
            healingItemInventory.TryChangeItemCount(startHealingItems);
            healingInventoryDisplayer.DisplayItemInventory(healingItemInventory);

            Healing healing = new(health, healingItemInventory);
            healing.MaxRestoredHealthPoints.Value = maxRestoredHealthPoints;
            healingDisplayer.DisplayHealing(healing);
            _disposable.Add(healing);

            Death death = new(health, deathPanel);
            _disposable.Add(death);

            Stat mana = new();
            mana.MaxStatPoints.Value = maxManaPoints;
            mana.ChangeStatPoints(startManaPoints);
            manaDisplayer.DisplayStat(mana);

            ItemInventory manaPotionInventory = new();
            manaPotionInventory.TryChangeItemCount(startManaPotions);
            manaPotionInventoryDisplayer.DisplayItemInventory(manaPotionInventory);

            ItemInventory coinInventory = new();
            coinInventory.TryChangeItemCount(startCoins);
            coinInventoryDisplayer.DisplayItemInventory(coinInventory);

            Warning warning = new(health, warningTab, criticalHealth);
            _disposable.Add(warning);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}