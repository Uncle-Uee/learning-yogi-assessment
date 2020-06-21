using UncleUee.Global;
using UnityEngine;

namespace UncleUee.UI
{
    public class HudUI : MonoBehaviour
    {
        #region VARIABLES

        [Header("Score Text")]
        public TMPro.TextMeshProUGUI ScoreText;

        #endregion

        #region METHODS

        public void UpdateScoreText(Variables variables)
        {
            ScoreText.SetText(variables.Score.ToString("000000000"));
        }

        #endregion
    }
}