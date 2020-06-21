using System.Collections;
using UncleUee.Global;
using UnityEngine;
using UnityEngine.Events;

namespace UncleUee.Managers
{
    public class PlayingTimeManager : MonoBehaviour
    {
        #region VARIABLES

        [Header("Game Variables")]
        public Variables Variables;

        [Header("Playing Time Properties")]
        public float PlayingTime = 0f;
        public float Interval = 30f;

        [Header("Events")]
        public UnityEvent OnIntervalReached = new UnityEvent();

        #endregion

        #region METHODS

        public void StartPlayingTimeTicker()
        {
            StopAllCoroutines();
            StartCoroutine(nameof(PlayingTimeTicker));
        }

        public IEnumerator PlayingTimeTicker()
        {
            WaitForSeconds ticker = new WaitForSeconds(1f);
            ResetPlayingTime();
            while (Variables.Playing)
            {
                PlayingTime += 1f;
                if (PlayingTime >= Interval)
                {
                    PlayingTime = 0;
                    OnIntervalReached.Invoke();
                }

                yield return ticker;
            }
        }

        private void ResetPlayingTime()
        {
            PlayingTime = 0f;
            Variables.ResetGroundSpeedMultiplier(1f);
            Variables.ResetSpawnDelay(4.5f);
            Variables.ResetObstacleSpeed(3f);
        }

        #endregion
    }
}