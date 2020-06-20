﻿// Created by Kearan Petersen : https://www.blumalice.wordpress.com | https://www.linkedin.com/in/kearan-petersen/

using UnityEngine;
using UnityEngine.Events;

namespace JellyFish.Internal.Utilities
{
    [CreateAssetMenu(menuName = "JellyFish/Utilities/Camera/Resolution State", order = 30)]
    public class ResolutionState : ScriptableObject
    {
        /// <summary>
        ///     The current screen resolution.
        /// </summary>
        private Vector2 _currentScreenResolution;

        /// <summary>
        /// The Current World Screen Size.
        /// </summary>
        private Vector2 _currentWorldScreenSize;

        /// <summary>
        ///     The screen resolution the application was designed for.
        /// </summary>
        public Vector2 DesignedScreenResolution;

        /// <summary>
        ///     Event raised when the screen resolution changes.
        /// </summary>
        public UnityEvent OnScreenResolutionChanged = new UnityEvent();

        /// <summary>
        ///     The current screen resolution.
        /// </summary>
        public Vector2 CurrentScreenResolution
        {
            get => _currentScreenResolution;
            set
            {
                _currentScreenResolution = value;
                OnScreenResolutionChanged.Invoke();
            }
        }

        /// <summary>
        /// The Current World Screen Size.
        /// </summary>
        public Vector2 CurrentWorldScreenSize
        {
            get => _currentWorldScreenSize;
            set => _currentWorldScreenSize = value;
        }

        /// <summary>
        /// Bound a Transform within the World.
        /// </summary>
        /// <param name="localPosition"></param>
        /// <returns></returns>
        public void BoundWithinScreen(ref Vector3 localPosition)
        {
            float worldHeight = _currentWorldScreenSize.y;
            float worldWidth  = _currentWorldScreenSize.x;

            localPosition.y = Mathf.Clamp(localPosition.y, -worldHeight, worldHeight);
            localPosition.x = Mathf.Clamp(localPosition.x, -worldWidth, worldWidth);
        }
    }
}