using R3;

namespace StatSystem
{
    public class Stat
    {
        private readonly ReactiveProperty<int> _statPoints = new();

        public ReactiveProperty<int> MaxStatPoints { get; } = new();
        public ReadOnlyReactiveProperty<int> StatPoints => _statPoints;

        public void ChangeStatPoints(int deltaPoints)
        {
            if (_statPoints.Value + deltaPoints > MaxStatPoints.Value)
            {
                _statPoints.Value = MaxStatPoints.Value;
                return;
            }

            if (_statPoints.Value + deltaPoints < 0)
            {
                _statPoints.Value = 0;
                return;
            }

            _statPoints.Value += deltaPoints;
        }
    }
}