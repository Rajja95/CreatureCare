using CreatureCare.KoiSystem;
using UnityEngine;
using UnityEngine.UI;

namespace CreatureCare.KoiSystem.Presentation.UI
{
    public class KoiStatsUI : MonoBehaviour
    {
        [SerializeField] private Image hungerFill;
        [SerializeField] private Image happinessFill;
        [SerializeField] private Image waterQualityFill;

        [SerializeField] private Koi _koi;

        private void Start()
        {
            _koi.Stats.StatsChanged += HandleStatsChanged;

            UpdateUI();
        }

        private void OnDestroy()
        {
            if (_koi != null && _koi.Stats != null)
            {
                _koi.Stats.StatsChanged -= HandleStatsChanged;
            }
        }

        private void HandleStatsChanged()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            hungerFill.fillAmount = _koi.Stats.Hunger / KoiStats.MaxValue;
            happinessFill.fillAmount = _koi.Stats.Happiness / KoiStats.MaxValue;
            waterQualityFill.fillAmount = _koi.Stats.WaterQuality / KoiStats.MaxValue;
        }
    }
}