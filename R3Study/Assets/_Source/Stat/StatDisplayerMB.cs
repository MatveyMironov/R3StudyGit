using CustomUISystem;
using R3;
using System;
using UnityEngine;

namespace StatSystem
{
    public class StatDisplayerMB : MonoBehaviour
    {
        [SerializeField] private ANumberDisplayerMB statPointsDisplayer;
        [SerializeField] private ANumberDisplayerMB maxStatPointsDisplayer;

        private CompositeDisposable _disposables;

        private void OnDestroy()
        {
            HideStat();
        }

        public void DisplayStat(Stat stat)
        {
            HideStat();

            _disposables = new();
            IDisposable statPointSubscription = stat.StatPoints.Subscribe(DisplayStatPoints);
            _disposables.Add(statPointSubscription);
            IDisposable maxStatPointsSubscription = stat.MaxStatPoints.Subscribe(DisplayMaxStatPoints);
        }

        public void HideStat()
        {
            _disposables?.Dispose();
        }

        private void DisplayStatPoints(int statPoints)
        {
            statPointsDisplayer.DisplayNumber(statPoints);
        }

        private void DisplayMaxStatPoints(int maxStatPoints)
        {
            maxStatPointsDisplayer.DisplayNumber(maxStatPoints);
        }
    }
}