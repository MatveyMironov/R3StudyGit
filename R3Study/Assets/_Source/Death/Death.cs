using StatSystem;
using R3;
using System;
using UnityEngine;

namespace DeathSystem
{
    public class Death : IDisposable
    {
        private readonly GameObject _deathPanel;
        private readonly IDisposable _subscription;

        public Death(Stat health, GameObject deathPanel)
        {
            if (health is null) { throw new ArgumentNullException(nameof(health)); }

            _deathPanel = deathPanel != null ? deathPanel : throw new ArgumentNullException(nameof(deathPanel));

            _subscription = health.StatPoints.Where(healthPoints => healthPoints <= 0).Subscribe(_ => Die());
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }

        private void Die()
        {
            _deathPanel.SetActive(true);
        }
    }
}