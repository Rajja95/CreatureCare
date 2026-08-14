using CreatureCare.Systems;
using TMPro;
using UnityEngine;

namespace CreatureCare.Core.Presentation
{
    public class DayUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text dayText;
        [SerializeField] private DayCycle dayCycle;

        private void Start()
        {
            dayCycle.DayChanged += HandleDayChanged;

            UpdateDayText(dayCycle.CurrentDay);
        }

        private void OnDestroy()
        {
            if (dayCycle != null)
            {
                dayCycle.DayChanged -= HandleDayChanged;
            }
        }

        private void HandleDayChanged(int currentDay)
        {
            UpdateDayText(currentDay);
        }

        private void UpdateDayText(int currentDay)
        {
            dayText.text = $"Day {currentDay} / 3";
        }
    }
}