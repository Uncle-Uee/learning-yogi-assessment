using System.Collections;
using UncleUee.Global;
using UnityEngine;
using UnityEngine.Events;

namespace UncleUee.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        #region VARIABLES

        [Header("Score")]
        public Variables GeneralVariables;
        public int ScoreIncrementValue  = 10;
        public int ScoreMultiplierValue = 500;
        public int MultiplierLimit      = 25;


        [Header("Events")]
        public UnityEvent OnScoreIncrement = new UnityEvent();

        private int _multiplier = 1;

        #endregion

        #region METHODS

        public void StartScoreTicker()
        {
            StopAllCoroutines();
            StartCoroutine(nameof(ScoreTicker));
        }

        public IEnumerator ScoreTicker()
        {
            WaitForSeconds ticker = new WaitForSeconds(1f);
            ResetScore();
            while (GeneralVariables.Playing)
            {
                ScoreMultiplier(out _multiplier);
                GeneralVariables.Score += ScoreIncrementValue * _multiplier;
                OnScoreIncrement.Invoke();
                yield return ticker;
            }
        }

        private void ScoreMultiplier(out int multiplier)
        {
            multiplier = GeneralVariables.Score / ScoreMultiplierValue;

            if (multiplier == 0)
            {
                multiplier = 1;
            }
            else if (multiplier > MultiplierLimit)
            {
                multiplier = MultiplierLimit;
            }
        }

        #endregion

        #region HELPER METHODS

        private void ResetScore()
        {
            GeneralVariables.Score = 0;
        }

        #endregion
    }
}