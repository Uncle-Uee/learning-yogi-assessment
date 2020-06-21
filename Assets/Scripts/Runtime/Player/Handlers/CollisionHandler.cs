using UncleUee.Global;
using UnityEngine;
using UnityEngine.Events;

namespace UncleUee.Player.Handlers
{
    public class CollisionHandler : MonoBehaviour
    {
        #region VARIABLES

        [Header("Game Variables")]
        public Variables Variables;

        [Header("Events")]
        public UnityEvent OnObstacleCollision = new UnityEvent();
        public UnityEvent OnCoinCollision = new UnityEvent();

        #endregion

        #region UNITY METHODS

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacles"))
            {
                if (!Variables.Playing) return;
                OnObstacleCollision.Invoke();
            }

            if (other.CompareTag("Items"))
            {
                OnCoinCollision.Invoke();
                Destroy(other.gameObject);
            }
        }

        #endregion
    }
}