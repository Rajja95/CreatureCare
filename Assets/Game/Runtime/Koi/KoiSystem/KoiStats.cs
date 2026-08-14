using System;

namespace CreatureCare.KoiSystem
{
    public enum KoiState
    {
        Happy,
        Normal,
        Unhappy,
        Sick,
        Dead
    }

    public class KoiStats
    {
        public const float MinValue = 0f;
        public const float MaxValue = 100f;

        public float Hunger { get; private set; }
        public float Happiness { get; private set; }
        public float WaterQuality { get; private set; }

        public event Action StatsChanged;

        public KoiStats(float hunger, float happiness, float waterQuality)
        {
            Hunger = Clamp(hunger);
            Happiness = Clamp(happiness);
            WaterQuality = Clamp(waterQuality);
        }

        public void ChangeHunger(float amount)
        {
            Hunger = Clamp(Hunger + amount);
            StatsChanged?.Invoke();
        }

        public void ChangeHappiness(float amount)
        {
            Happiness = Clamp(Happiness + amount);
            StatsChanged?.Invoke();
        }

        public void ChangeWaterQuality(float amount)
        {
            WaterQuality = Clamp(WaterQuality + amount);
            StatsChanged?.Invoke();
        }

        private static float Clamp(float value)
        {
            return Math.Clamp(value, MinValue, MaxValue);
        }
    }
}