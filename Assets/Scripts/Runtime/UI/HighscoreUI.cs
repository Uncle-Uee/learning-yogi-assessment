using UncleUee.Global;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace UncleUee.UI
{
    public class HighscoreUI : MonoBehaviour
    {
        #region VARIABLES

        [Header("General Variable")]
        public Variables Variables;

        [Header("Highscore Text")]
        public TextMeshProUGUI HighsoreText;
        public TextMeshProUGUI CurrentHighsoreText;

        [Header("Events")]
        public UnityEvent OnEnableEvent = new UnityEvent();
        public UnityEvent OnClickBack = new UnityEvent();
        public UnityEvent OnClickRetry = new UnityEvent();

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            if (Variables.Highscore < Variables.Score)
            {
                Variables.Highscore = Variables.Score;
            }

            HighsoreText.SetText($"Highscore: {Variables.Highscore}");
            CurrentHighsoreText.SetText($"Current Score: {Variables.Score}");

            OnEnableEvent.Invoke();
        }

        #endregion

        #region METHODS

        public void ClickBack()
        {
            OnClickBack.Invoke();
            gameObject.SetActive(false);
        }

        public void ClickRetry()
        {
            OnClickRetry.Invoke();
            gameObject.SetActive(false);
        }

        #endregion
    }
}