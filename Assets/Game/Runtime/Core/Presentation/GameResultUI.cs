using CreatureCare.Core;
using UnityEngine;

namespace CreatureCare.Core.Presentation
{
    public class GameResultUI : MonoBehaviour
    {
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private GameObject actionsPanel;

        private void Start()
        {
            winPanel.SetActive(false);
            losePanel.SetActive(false);
        }

        public void ShowWin()
        {
            actionsPanel.SetActive(false);
            winPanel.SetActive(true);
        }

        public void ShowLose()
        {
            actionsPanel.SetActive(false);
            losePanel.SetActive(true);
        }
    }
}