using UnityEngine;

namespace CreatureCare.KoiSystem.Actions
{
    public class KoiCareActions : MonoBehaviour
    {
        private Koi _koi;

        private KoiCareActionCooldown _feedCooldown;
        private KoiCareActionCooldown _playCooldown;
        private KoiCareActionCooldown _cleanPondCooldown;

        private void Awake()
        {
            _koi = GetComponent<Koi>();

            _feedCooldown = new KoiCareActionCooldown(5f);
            _playCooldown = new KoiCareActionCooldown(8f);
            _cleanPondCooldown = new KoiCareActionCooldown(6f);
        }

        private void Start()
        {
            Debug.Log($"Hunger: {_koi.Stats.Hunger}");
            Debug.Log($"Happiness: {_koi.Stats.Happiness}");
            Debug.Log($"Water Quality: {_koi.Stats.WaterQuality}");
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;

            _feedCooldown.Update(deltaTime);
            _playCooldown.Update(deltaTime);
            _cleanPondCooldown.Update(deltaTime);
        }

        public bool Feed()
        {
            if (!_feedCooldown.IsReady)
            {
                return false;
            }

            _koi.Stats.ChangeHunger(25f);
            _koi.Stats.ChangeWaterQuality(-5f);

            _feedCooldown.Start();

            return true;
        }

        public bool Play()
        {
            if (!_playCooldown.IsReady)
            {
                return false;
            }

            _koi.Stats.ChangeHappiness(25f);
            _koi.Stats.ChangeHunger(-5f);

            _playCooldown.Start();

            return true;
        }

        public bool CleanPond()
        {
            if (!_cleanPondCooldown.IsReady)
            {
                return false;
            }

            _koi.Stats.ChangeWaterQuality(30f);
            _koi.Stats.ChangeHappiness(5f);

            _cleanPondCooldown.Start();

            return true;
        }
    }
}