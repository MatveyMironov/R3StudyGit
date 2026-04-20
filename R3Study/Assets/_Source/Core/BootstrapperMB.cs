using DeathSystem;
using HealingSystem;
using StatSystem;
using InventorySystem;
using R3;
using UnityEngine;
using SpellSystem;

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

        [Header("Mana Healing")]
        [SerializeField] private int startManaPotions;
        [SerializeField] private ItemInventoryDisplayerMB manaPotionInventoryDisplayer;
        [SerializeField] private int maxRestoredManaPoints;
        [SerializeField] private HealingDisplayerMB manaHealingDisplayer;

        [Header("Spell Cast")]
        [SerializeField] private int requiredManaPoints;
        [SerializeField] private int spentManaPoints;
        [SerializeField] private SpellCastDisplayerMB spellCastDisplayer;

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

            Healing manaHealing = new(mana, manaPotionInventory);
            manaHealing.MaxRestoredHealthPoints.Value = maxRestoredManaPoints;
            manaHealingDisplayer.DisplayHealing(manaHealing);
            _disposable.Add(manaHealing);

            SpellCast spellCast = new(mana);
            spellCast.RequiredManaPoints.Value = requiredManaPoints;
            spellCast.SpentManaPoints.Value = spentManaPoints;
            spellCastDisplayer.DisplaySpellCast(spellCast);
            _disposable.Add(spellCast);

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