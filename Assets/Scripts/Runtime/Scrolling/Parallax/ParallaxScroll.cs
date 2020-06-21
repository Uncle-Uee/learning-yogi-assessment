using UncleUee.Global;
using UnityEngine;

namespace UncleUee.Scrolling.Ground
{
    public class ParallaxScroll : MonoBehaviour
    {
        #region VARIABLES

        [Header("Required Components")]
        public Animator Animator;

        private readonly int _multiplier = Animator.StringToHash("Multiplier");

        #endregion

        #region METHODS

        public void SetMultiplier(float value)
        {
            Animator.SetFloat(_multiplier, value);
        }

        public void SetMultiplier(Variables variables)
        {
            Animator.SetFloat(_multiplier, variables.GroundSpeedMultiplier);
        }

        #endregion
    }
}