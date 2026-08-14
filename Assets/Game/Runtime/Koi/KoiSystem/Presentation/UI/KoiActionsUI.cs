using CreatureCare.KoiSystem;
using CreatureCare.KoiSystem.Actions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CreatureCare.KoiSystem.Presentation.UI
{
    public class KoiActionsUI : MonoBehaviour
    {
        [SerializeField] private Button feedButton;
        [SerializeField] private Button playButton;
        [SerializeField] private Button cleanPondButton;

        [SerializeField] private TMP_Text feedCooldownText;
        [SerializeField] private TMP_Text playCooldownText;
        [SerializeField] private TMP_Text cleanPondCooldownText;

        [SerializeField] private KoiActionFeedbackUI feedbackUI;

        [SerializeField] private KoiCareActions koiCareActions;

        private void Start()
        {
            feedButton.onClick.AddListener(HandleFeedClicked);
            playButton.onClick.AddListener(HandlePlayClicked);
            cleanPondButton.onClick.AddListener(HandleCleanPondClicked);
        }

        private void OnDestroy()
        {
            feedButton.onClick.RemoveListener(HandleFeedClicked);
            playButton.onClick.RemoveListener(HandlePlayClicked);
            cleanPondButton.onClick.RemoveListener(HandleCleanPondClicked);
        }

        private void Update()
        {
            UpdateCooldownDisplay();
        }

        private void HandleFeedClicked()
        {
            if (koiCareActions.Feed())
            {
                feedbackUI.ShowFeedFeedback();
            }
        }

        private void HandlePlayClicked()
        {
            if (koiCareActions.Play())
            {
                feedbackUI.ShowPlayFeedback();
            }
        }

        private void HandleCleanPondClicked()
        {
            if (koiCareActions.CleanPond())
            {
                feedbackUI.ShowCleanPondFeedback();
            }
        }

        private void UpdateCooldownDisplay()
        {
            feedButton.interactable = koiCareActions.FeedCooldownRemaining <= 0f;
            playButton.interactable = koiCareActions.PlayCooldownRemaining <= 0f;
            cleanPondButton.interactable = koiCareActions.CleanPondCooldownRemaining <= 0f;

            UpdateCooldownText(
                feedCooldownText,
                koiCareActions.FeedCooldownRemaining);

            UpdateCooldownText(
                playCooldownText,
                koiCareActions.PlayCooldownRemaining);

            UpdateCooldownText(
                cleanPondCooldownText,
                koiCareActions.CleanPondCooldownRemaining);
        }

        private static void UpdateCooldownText(TMP_Text text, float remainingTime)
        {
            if (remainingTime <= 0f)
            {
                text.text = string.Empty;
                return;
            }

            text.text = $"{remainingTime:F1}s";
        }
    }
}