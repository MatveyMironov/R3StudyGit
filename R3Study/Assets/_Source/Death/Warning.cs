using StatSystem;
using R3;
using System;
using UnityEngine;

namespace DeathSystem
{
    public class Warning : IDisposable
    {
        private readonly GameObject _warningTab;
        private readonly int _criticalHealthPoints;

        public Warning(Stat health, GameObject warningTab, int criticalHealthPoints)
        {
            if (health is null) { throw new ArgumentNullException(nameof(health)); }

            _warningTab = warningTab != null ? warningTab : throw new ArgumentNullException(nameof(warningTab));
            _criticalHealthPoints = criticalHealthPoints;

            StartWarning(health);
        }

        private IDisposable _startWarningSubscription;
        private IDisposable _stopWarningSubscription;

        private void StartWarning(Stat health)
        {
            _warningTab.SetActive(true);
            _startWarningSubscription?.Dispose();
            _stopWarningSubscription = health.StatPoints.Where(healthPoints => healthPoints > _criticalHealthPoints).Subscribe(_ => StopWarning(health));
        }

        private void StopWarning(Stat health)
        {
            _warningTab.SetActive(false);
            _stopWarningSubscription?.Dispose();
            _startWarningSubscription = health.StatPoints.Where(healthPoints => healthPoints <= _criticalHealthPoints).Subscribe(_ => StartWarning(health));
        }

        public void Dispose()
        {
            _startWarningSubscription?.Dispose();
            _stopWarningSubscription?.Dispose();
        }
    }
}