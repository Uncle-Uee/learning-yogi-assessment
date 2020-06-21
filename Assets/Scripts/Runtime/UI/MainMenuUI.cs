using UnityEngine;
using UnityEngine.Events;

namespace UncleUee.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        #region VARIABLES

        [Header("Events")]
        public UnityEvent OnEnableEvent = new UnityEvent();
        public UnityEvent OnClickPlay = new UnityEvent();

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            OnEnableEvent.Invoke();
        }

        #endregion

        #region METHODS

        public void ClickPlay()
        {
            OnClickPlay.Invoke();
            gameObject.SetActive(false);
        }

        public void ClickQuit()
        {
            Application.Quit();
        }

        #endregion
    }
}