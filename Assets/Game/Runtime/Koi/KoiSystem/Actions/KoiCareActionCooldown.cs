using UnityEngine;

namespace CreatureCare.KoiSystem.Actions
{
    public class KoiCareActionCooldown
    {
        private readonly float _duration;
        private float _remainingTime;

        public bool IsReady => _remainingTime <= 0f;

        public float RemainingTime => _remainingTime;

        public KoiCareActionCooldown(float duration)
        {
            _duration = duration;
        }

        public void Start()
        {
            _remainingTime = _duration;
        }

        public void Update(float deltaTime)
        {
            if (_remainingTime <= 0f)
            {
                return;
            }

            _remainingTime = Mathf.Max(0f, _remainingTime - deltaTime);
        }
    }
}