using CreatureCare.KoiSystem;
using UnityEngine;

namespace CreatureCare.KoiSystem.Presentation
{
    public class KoiVisualController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private Koi _koi;

        private void Awake()
        {
            _koi = GetComponent<Koi>();
        }

        private void Start()
        {
            _koi.StateController.StateChanged += HandleStateChanged;

            HandleStateChanged(_koi.StateController.CurrentState);
        }

        private void OnDestroy()
        {
            if (_koi != null && _koi.StateController != null)
            {
                _koi.StateController.StateChanged -= HandleStateChanged;
            }
        }

        private void HandleStateChanged(KoiState state)
        {
            switch (state)
            {
                case KoiState.Happy:
                    SetHappyVisual();
                    break;

                case KoiState.Normal:
                    SetNormalVisual();
                    break;

                case KoiState.Unhappy:
                    SetUnhappyVisual();
                    break;

                case KoiState.Sick:
                    SetSickVisual();
                    break;

                case KoiState.Dead:
                    SetDeadVisual();
                    break;
            }
        }

        private void SetHappyVisual()
        {
            spriteRenderer.color = Color.white;
        }

        private void SetNormalVisual()
        {
            spriteRenderer.color = Color.white;
        }

        private void SetUnhappyVisual()
        {
            spriteRenderer.color = Color.gray;
        }

        private void SetSickVisual()
        {
            spriteRenderer.color = Color.yellow;
        }

        private void SetDeadVisual()
        {
            spriteRenderer.color = Color.gray;
        }
    }
}