using UnityEngine;

namespace UncleUee.Obstacles.Cleanup
{
    public class ObjectEOL : MonoBehaviour
    {
        #region UNITY METHODS

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Obstacles"))
            {
                Destroy(other.gameObject);
            }
        }

        #endregion
    }
}