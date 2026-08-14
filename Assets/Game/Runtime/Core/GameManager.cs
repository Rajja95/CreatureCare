using CreatureCare.KoiSystem;
using CreatureCare.Systems;
using UnityEngine;

namespace CreatureCare.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private KoiSystem.Koi _koi;
        [SerializeField] private DayCycle _dayCycle;

        public GameState CurrentState { get; private set; }

        private const int TargetDay = 3;

        private void Awake()
        {
            CurrentState = GameState.Playing;
        }

        private void Start()
        {
            _dayCycle.DayCompleted += HandleDayCompleted;
            _koi.StateController.StateChanged += HandleKoiStateChanged;
        }

        private void OnDestroy()
        {
            if (_dayCycle != null)
            {
                _dayCycle.DayCompleted -= HandleDayCompleted;
            }

            if (_koi != null && _koi.StateController != null)
            {
                _koi.StateController.StateChanged -= HandleKoiStateChanged;
            }
        }

        private void HandleDayCompleted(int completedDay)
        {
            if (completedDay >= TargetDay)
            {
                WinGame();
            }
        }

        private void HandleKoiStateChanged(KoiState state)
        {
            if (state == KoiState.Dead)
            {
                LoseGame();
            }
        }

        private void WinGame()
        {
            if (CurrentState != GameState.Playing)
            {
                return;
            }

            CurrentState = GameState.Won;
            _dayCycle.Stop();

            Debug.Log("Koi survived for 3 days! You win!");
        }

        private void LoseGame()
        {
            if (CurrentState != GameState.Playing)
            {
                return;
            }

            CurrentState = GameState.Lost;
            _dayCycle.Stop();

            Debug.Log("The Koi has died. Game Over.");
        }
    }
}