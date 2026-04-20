using R3;
using StatSystem;
using System;

namespace SpellSystem
{
    public class SpellCast : IDisposable
    {
        private readonly Stat _mana;

        private readonly ReactiveProperty<bool> _isAbleToCastSpell = new();

        public SpellCast(Stat mana)
        {
            _mana = mana ?? throw new ArgumentNullException(nameof(mana));

            BecomeUnaibleToCastSpell();
        }

        private IDisposable _manaPointsLowSubscription;
        private IDisposable _manaPointsHighSubscription;

        public ReactiveProperty<int> RequiredManaPoints { get; } = new();
        public ReactiveProperty<int> SpentManaPoints { get; } = new();
        public ReadOnlyReactiveProperty<bool> IsAbleToCastSpell => _isAbleToCastSpell;

        public bool TryCastSpell()
        {
            if (!_isAbleToCastSpell.CurrentValue) { return false; }

            _mana.ChangeStatPoints(-SpentManaPoints.CurrentValue);
            return true;
        }

        public void Dispose()
        {
            _manaPointsLowSubscription?.Dispose();
            _manaPointsHighSubscription?.Dispose();
        }

        private void BecomeUnaibleToCastSpell()
        {
            _isAbleToCastSpell.Value = false;
            _manaPointsLowSubscription?.Dispose();
            _manaPointsHighSubscription = _mana.StatPoints.Where(points => points >= RequiredManaPoints.CurrentValue).Subscribe(_ => BecomeAibleToCastSpell());
        }

        private void BecomeAibleToCastSpell()
        {
            _isAbleToCastSpell.Value = true;
            _manaPointsHighSubscription?.Dispose();
            _manaPointsLowSubscription = _mana.StatPoints.Where(points => points < RequiredManaPoints.CurrentValue).Subscribe(_ => BecomeUnaibleToCastSpell());
        }
    }
}