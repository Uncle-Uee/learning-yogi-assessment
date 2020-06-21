using UnityEngine;
using UnityEngine.Events;

namespace UncleUee.Player.Behaviours
{
    public class MovementBehaviour : MonoBehaviour
    {
        #region VARIABLES

        [Header("Debug")]
        public bool DrawGizmos = true;

        [Header("Required Components")]
        public Rigidbody2D Rigidbody2D;

        [Header("Jump Properties")]
        public int AvailableJumps = 1;
        public float JumpForce       = 8f;
        public float MaxFallingSpeed = -10f;


        [Header("Environment Check Properties")]
        public LayerMask GroundLayer;
        public float     Radius;
        public Transform GroundCheck;

        [Header("Status Flags")]
        public bool IsOnGround;
        public bool IsJumping;

        [Header("Events")]
        public UnityEvent OnJump = new UnityEvent();

        private float _jumpCount = 0;

        #endregion

        #region METHODS

        public void PhysicsCheck()
        {
            if (Rigidbody2D.velocity.y <= 0.1f)
                IsOnGround = Physics2D.OverlapCircle(GroundCheck.position, Radius, GroundLayer);
        }

        public void Jump(bool jumpPressed)
        {
            if (jumpPressed && !IsJumping)
            {
                IsOnGround =  false;
                IsJumping  =  true;
                _jumpCount += 1;

                OnJump.Invoke();
                Rigidbody2D.AddForce(new Vector2(Rigidbody2D.velocity.x, JumpForce), ForceMode2D.Impulse);
            }

            if (Rigidbody2D.velocity.y <= MaxFallingSpeed)
            {
                // ToDo : Make Cached Vector2
                Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, MaxFallingSpeed);
            }

            if (IsOnGround)
            {
                IsJumping  = false;
                _jumpCount = 0;
            }
        }

        #endregion

        #region GIZMOS

        private void OnDrawGizmos()
        {
            if (DrawGizmos)
            {
                Gizmos.color = IsOnGround ? Color.red : Color.green;
                Gizmos.DrawWireSphere(GroundCheck.position, Radius);
            }
        }

        #endregion
    }
}