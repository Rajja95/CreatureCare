using System;

namespace CreatureCare.KoiSystem
{
    public class KoiStateController
    {
        public KoiState CurrentState { get; private set; }

        public event Action<KoiState> StateChanged;

        public KoiStateController(KoiStats stats)
        {
            CurrentState = EvaluateState(stats);
        }

        public void Evaluate(KoiStats stats)
        {
            KoiState newState = EvaluateState(stats);

            if (newState == CurrentState)
            {
                return;
            }

            CurrentState = newState;
            StateChanged?.Invoke(CurrentState);
        }

        private static KoiState EvaluateState(KoiStats stats)
        {
            float lowestStat = Math.Min(stats.Hunger, Math.Min(stats.Happiness,stats.WaterQuality));

            if (lowestStat <= 0f)
            {
                return KoiState.Dead;
            }

            if (lowestStat < 20f)
            {
                return KoiState.Sick;
            }

            if (lowestStat < 40f)
            {
                return KoiState.Unhappy;
            }

            if (lowestStat < 70f)
            {
                return KoiState.Normal;
            }

            return KoiState.Happy;
        }
    }
}