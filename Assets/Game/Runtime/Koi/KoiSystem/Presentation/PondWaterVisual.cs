using CreatureCare.KoiSystem;
using UnityEngine;

namespace CreatureCare.KoiSystem.Presentation
{
    public class PondWaterVisual : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer waterRenderer;

        [Header("Water Colors")]
        [SerializeField] private Color cleanWaterColor = new Color(0.2f, 0.6f, 1f);
        [SerializeField] private Color dirtyWaterColor = new Color(0.3f, 0.7f, 0.2f);

        [SerializeField] private Koi koi;

        private void Start()
        {
            koi.Stats.StatsChanged += HandleStatsChanged;

            UpdateWaterColor();
        }

        private void OnDestroy()
        {
            if (koi != null && koi.Stats != null)
            {
                koi.Stats.StatsChanged -= HandleStatsChanged;
            }
        }

        private void HandleStatsChanged()
        {
            UpdateWaterColor();
        }

        private void UpdateWaterColor()
        {
            float quality = koi.Stats.WaterQuality / KoiStats.MaxValue;

            waterRenderer.color = Color.Lerp(
                dirtyWaterColor,
                cleanWaterColor,
                quality);
        }
    }
}