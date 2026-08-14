using System;
using UnityEngine;

namespace CreatureCare.Systems
{
    public class DayCycle : MonoBehaviour
    {
        [SerializeField] private float dayDuration = 60f;

        public int CurrentDay { get; private set; } = 1;

        public float ElapsedTime { get; private set; }

        public bool IsRunning { get; private set; }

        public event Action<int> DayChanged;
        public event Action<int> DayCompleted;

        private void Start()
        {
            IsRunning = true;
        }

        private void Update()
        {
            if (!IsRunning)
            {
                return;
            }

            ElapsedTime += Time.deltaTime;

            if (ElapsedTime >= dayDuration)
            {
                CompleteDay();
            }
        }

        public void Stop()
        {
            IsRunning = false;
        }

        private void CompleteDay()
        {
            ElapsedTime -= dayDuration;

            DayCompleted?.Invoke(CurrentDay);

            CurrentDay++;

            DayChanged?.Invoke(CurrentDay);
        }
    }
}