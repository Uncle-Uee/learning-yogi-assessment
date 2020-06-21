using UncleUee.Global;
using UnityEngine;

namespace UncleUee.Obstacles.Behaviours
{
    public class MovementBehaviour : MonoBehaviour
    {
        #region VARIABLES

        [Header("Game Variables")]
        public Variables Variables;

        private Vector2 _position;

        #endregion

        #region UNITY METHODS

        private void OnEnable()
        {
            _position = transform.position;
        }

        #endregion

        #region METHODS

        public void MoveObstacle()
        {
            if (!Variables.Playing) return;
            _position          += Vector2.left * (Variables.ObstacleSpeed * Time.deltaTime);
            transform.position =  _position;
        }

        #endregion
    }
}