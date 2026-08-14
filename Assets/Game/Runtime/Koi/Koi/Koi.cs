using UnityEngine;

namespace CreatureCare.Koi
{
    public class Koi : MonoBehaviour
    {
        public KoiStats Stats { get; private set; }
        public KoiStateController StateController { get; private set; }

        private void Awake()
        {
            Stats = new KoiStats(hunger: 80f, happiness: 80f, waterQuality: 80f);

            StateController = new KoiStateController(Stats);

            Stats.StatsChanged += HandleStatsChanged;
        }

        private void Start()
        {
            Debug.Log($"Hunger: {Stats.Hunger}");
            Debug.Log($"Happiness: {Stats.Happiness}");
            Debug.Log($"Water Quality: {Stats.WaterQuality}");
        }

        private void OnDestroy()
        {
            Stats.StatsChanged -= HandleStatsChanged;
        }

        private void HandleStatsChanged()
        {
            StateController.Evaluate(Stats);
            Debug.Log($"Koi State: {StateController.CurrentState}");
        }
    }
}