using UnityEngine;

namespace UncleUee.Player.Controller
{
    public class AnimationController : MonoBehaviour
    {
        #region VARIABLES

        [Header("Required Components")]
        public Animator Animator;

        private readonly int _speed = Animator.StringToHash("Speed");
        private readonly int _death = Animator.StringToHash("Death");
        private readonly int _jump  = Animator.StringToHash("Jump");

        #endregion

        #region METHODS

        public void SetSpeed(float value)
        {
            Animator.SetFloat(_speed, value);
        }

        public void SetJump(bool value)
        {
            Animator.SetBool(_jump, value);
        }

        public void InvokeDeath()
        {
            Animator.SetTrigger(_death);
        }

        #endregion
    }
}