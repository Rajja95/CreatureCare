using CreatureCare.KoiSystem;
using System.Collections;
using UnityEngine;
using CreatureCare.Audio;
using TMPro;

namespace CreatureCare.KoiSystem.Presentation
{
    public class KoiVisualController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        [Header("State Sprites")]
        [SerializeField] private Sprite happySprite;
        [SerializeField] private Sprite normalSprite;
        [SerializeField] private Sprite unhappySprite;
        [SerializeField] private Sprite sickSprite;
        [SerializeField] private Sprite deadSprite;

        [SerializeField] private float statePopupScale = 1.2f;
        [SerializeField] private float statePopupDuration = 0.2f;

        private Coroutine _popupCoroutine;
        private Vector3 _originalScale;

        [SerializeField] private TMP_Text stateMessageText;
        [SerializeField] private float messageDuration = 1.5f;

        private Koi _koi;

        private void Awake()
        {
            _koi = GetComponent<Koi>();

            _originalScale = transform.localScale;
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
            spriteRenderer.sprite = GetSpriteForState(state);
            AudioManager.Instance.PlayStateChange();

            ShowStateMessage(state);

            if (_popupCoroutine != null)
            {
                StopCoroutine(_popupCoroutine);
            }

            _popupCoroutine = StartCoroutine(PlayStatePopup());
        }

        private Sprite GetSpriteForState(KoiState state)
        {
            return state switch
            {
                KoiState.Happy => happySprite,
                KoiState.Normal => normalSprite,
                KoiState.Unhappy => unhappySprite,
                KoiState.Sick => sickSprite,
                KoiState.Dead => deadSprite,
                _ => normalSprite
            };
        }

        private IEnumerator PlayStatePopup()
        {
            float halfDuration = statePopupDuration * 0.5f;

            Vector3 popupScale = _originalScale * statePopupScale;

            float elapsed = 0f;

            while (elapsed < halfDuration)
            {
                elapsed += Time.deltaTime;

                float t = elapsed / halfDuration;

                transform.localScale = Vector3.Lerp(
                    _originalScale,
                    popupScale,
                    t);

                yield return null;
            }

            elapsed = 0f;

            while (elapsed < halfDuration)
            {
                elapsed += Time.deltaTime;

                float t = elapsed / halfDuration;

                transform.localScale = Vector3.Lerp(
                    popupScale,
                    _originalScale,
                    t);

                yield return null;
            }

            transform.localScale = _originalScale;
            _popupCoroutine = null;
        }

        private void ShowStateMessage(KoiState state)
        {
            stateMessageText.text = GetStateMessage(state);
            stateMessageText.gameObject.SetActive(true);

            CancelInvoke(nameof(HideStateMessage));
            Invoke(nameof(HideStateMessage), messageDuration);
        }

        private void HideStateMessage()
        {
            stateMessageText.gameObject.SetActive(false);
        }

        private string GetStateMessage(KoiState state)
        {
            return state switch
            {
                KoiState.Happy => "I'm feeling great!",
                KoiState.Normal => "I'm okay.",
                KoiState.Unhappy => "I'm hungry...",
                KoiState.Sick => "I don't feel well...",
                KoiState.Dead => "...",
                _ => string.Empty
            };
        }
    }

}