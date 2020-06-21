using UncleUee.Obstacles.Behaviours;
using UnityEngine;

namespace UncleUee.Obstacles.Controller
{
    public class ObstaclesController : MonoBehaviour
    {
        #region VARIABLES

        [Header("Required Behaviours")]
        public MovementBehaviour MovementBehaviour;

        #endregion

        #region UNITY METHODS

        private void Update()
        {
            MovementBehaviour.MoveObstacle();
        }

        #endregion
    }
}