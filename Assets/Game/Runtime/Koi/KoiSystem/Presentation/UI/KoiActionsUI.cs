using CreatureCare.KoiSystem;
using CreatureCare.KoiSystem.Actions;
using UnityEngine;
using UnityEngine.UI;

namespace CreatureCare.KoiSystem.Presentation.UI
{
    public class KoiActionsUI : MonoBehaviour
    {
        [SerializeField] private Button feedButton;
        [SerializeField] private Button playButton;
        [SerializeField] private Button cleanPondButton;

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

        private void HandleFeedClicked()
        {
            koiCareActions.Feed();
        }

        private void HandlePlayClicked()
        {
            koiCareActions.Play();
        }

        private void HandleCleanPondClicked()
        {
            koiCareActions.CleanPond();
        }
    }
}