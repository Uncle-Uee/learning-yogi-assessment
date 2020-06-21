using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UncleUee.Player.Entity
{
    public class PlayerEntity : MonoBehaviour
    {
        #region METHODS

        public void Reset()
        {
            Deactivate();
            Activate();
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        #endregion
    }
}