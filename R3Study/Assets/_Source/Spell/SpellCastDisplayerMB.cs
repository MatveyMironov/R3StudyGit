using R3;
using System;
using UnityEngine;

namespace SpellSystem
{
    public class SpellCastDisplayerMB : MonoBehaviour
    {
        [SerializeField] private GameObject spellCastButton;

        private SpellCast _displayedSpellCast;
        private IDisposable _subscription;

        private void OnDestroy()
        {
            HideSpellCast();
        }

        public void DisplaySpellCast(SpellCast spellCast)
        {
            HideSpellCast();
            _displayedSpellCast = spellCast;
            _subscription = spellCast.IsAbleToCastSpell.Subscribe(DisplayIsAibleToCastSpell);
        }

        public void HideSpellCast()
        {
            _subscription?.Dispose();
            _displayedSpellCast = null;
        }

        public void CastSpell()
        {
            if (_displayedSpellCast == null) { return; }

            _displayedSpellCast.TryCastSpell();
        }

        private void DisplayIsAibleToCastSpell(bool isAble)
        {
            spellCastButton.SetActive(isAble);
        }
    }
}