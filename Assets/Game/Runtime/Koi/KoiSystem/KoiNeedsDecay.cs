using UnityEngine;

namespace CreatureCare.KoiSystem
{
    public class KoiNeedsDecay : MonoBehaviour
    {
        [SerializeField] private float hungerDecayPerSecond = 0.5f;
        [SerializeField] private float happinessDecayPerSecond = 0.25f;
        [SerializeField] private float waterQualityDecayPerSecond = 0.2f;

        private Koi _koi;

        private void Awake()
        {
            _koi = GetComponent<Koi>();
        }

        private void Update()
        {
            ApplyDecay(Time.deltaTime);
        }

        private void ApplyDecay(float deltaTime)
        {
            _koi.Stats.ChangeHunger(-hungerDecayPerSecond * deltaTime);
            _koi.Stats.ChangeHappiness(-happinessDecayPerSecond * deltaTime);
            _koi.Stats.ChangeWaterQuality(-waterQualityDecayPerSecond * deltaTime);
        }
    }
}