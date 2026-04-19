using R3;

namespace HealthSystem
{
    public class Health
    {
        private readonly ReactiveProperty<int> _healthPoints = new();

        public ReactiveProperty<int> MaxHealthPoints { get; } = new();
        public ReadOnlyReactiveProperty<int> HealthPoints => _healthPoints;

        public void ChangeHealthPoints(int deltaPoints)
        {
            if (_healthPoints.Value + deltaPoints > MaxHealthPoints.Value)
            {
                _healthPoints.Value = MaxHealthPoints.Value;
                return;
            }

            if (_healthPoints.Value + deltaPoints < 0)
            {
                _healthPoints.Value = 0;
                return;
            }

            _healthPoints.Value += deltaPoints;
        }
    }
}