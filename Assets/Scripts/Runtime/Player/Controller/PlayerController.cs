using UncleUee.Global;
using UncleUee.Player.Behaviours;
using UnityEngine;

namespace UncleUee.Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        #region VARIABLES

        [Header("Required Controller")]
        public AnimationController AnimationController;

        [Header("Game Variables")]
        public Variables Variables;

        [Header("Required Movements")]
        public MovementBehaviour MovementBehaviour;

        [HideInInspector]
        public bool JumpPressed;

        #endregion

        #region UNITY METHODS

        private void Update()
        {
            AnimationController.SetSpeed(Variables.Playing ? 1f : 0f);

            if (!Variables.Playing) return;

#if UNITY_ANDROID || UNITY_IOS
            JumpPressed = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
#endif
#if UNITY_EDITOR || UNITY_STANDALONE
            JumpPressed = Input.GetButtonDown("Jump");
#endif

            MovementBehaviour.Jump(JumpPressed);
            AnimationController.SetJump(MovementBehaviour.IsJumping);
        }

        private void FixedUpdate()
        {
            MovementBehaviour.PhysicsCheck();
        }

        #endregion
    }
}