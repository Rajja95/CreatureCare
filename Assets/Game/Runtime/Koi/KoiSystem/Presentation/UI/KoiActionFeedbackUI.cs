using System.Collections;
using TMPro;
using UnityEngine;

namespace CreatureCare.KoiSystem.Presentation.UI
{
    public class KoiActionFeedbackUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text feedbackText;
        [SerializeField] private float displayDuration = 1.5f;

        private Coroutine _displayCoroutine;

        public void ShowFeedFeedback()
        {
            ShowFeedback("Yum!");
        }

        public void ShowPlayFeedback()
        {
            ShowFeedback("Yay!");
        }

        public void ShowCleanPondFeedback()
        {
            ShowFeedback("Fresh water!");
        }

        private void ShowFeedback(string message)
        {
            if (_displayCoroutine != null)
            {
                StopCoroutine(_displayCoroutine);
            }

            _displayCoroutine = StartCoroutine(DisplayFeedback(message));
        }

        private IEnumerator DisplayFeedback(string message)
        {
            feedbackText.text = message;
            feedbackText.gameObject.SetActive(true);

            yield return new WaitForSeconds(displayDuration);

            feedbackText.gameObject.SetActive(false);

            _displayCoroutine = null;
        }
    }
}