﻿// Created by Kearan Petersen : https://www.blumalice.wordpress.com | https://www.linkedin.com/in/kearan-petersen/

using UnityEngine;

namespace JellyFish.Data.Primitive
{
    [CreateAssetMenu(menuName = "JellyFish/Data/Primitives/Float", order = 10)]
    public class FloatData : PrimitiveData
    {
        /// <summary>
        ///     Determines whether the true asset value should retain
        ///     value changes during Play Mode.
        /// </summary>
        public bool PersistInPlayMode;

        /// <summary>
        ///     The true asset value of this data.
        /// </summary>
        public float AssetValue;

        /// <summary>
        ///     The Play Mode safe representation of this data.
        /// </summary>
        [SerializeField]
        protected float _playModeValue;

        /// <summary>
        ///     The value for this data.
        /// </summary>
        public float Value
        {
            get
            {
#if UNITY_EDITOR
                // Return the Play Mode safe representation of the data during
                // Play Mode.
                if (Application.isPlaying) return _playModeValue;
#endif
                // Always return the true asset value during Edit Mode.
                return AssetValue;
            }
            set
            {
#if UNITY_EDITOR
                if (Application.isPlaying)
                {
                    // Only alter the Play Mode safe representation of
                    // this data during Play Mode.
                    if (!_playModeValue.Equals(value))
                    {
                        _playModeValue = value;

                        if (PersistInPlayMode)
                            // If desired, the true asset value can maintain
                            // the changes created during Play Mode.
                            AssetValue = value;
                    }
                }
                else
                {
                    if (!AssetValue.Equals(value))
                    {
                        AssetValue = value;
                    }
                }
#else
                if(!AssetValue.Equals(value))
                {
                    AssetValue = value;
                }
#endif
            }
        }

        /// <summary>
        ///     Returns the value of this data.
        /// </summary>
        /// <returns></returns>
        public float GetValue()
        {
            return Value;
        }

        /// <inheritdoc />
        public override object GetValueData()
        {
            return Value;
        }

        /// <inheritdoc />
        public override void ResetValue()
        {
            base.ResetValue();

            _playModeValue = AssetValue;
        }

        /// <summary>
        ///     Attempts to set the value of this data to the supplied value.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(FloatData value)
        {
            Value = value.Value;
        }

        #region Base Modifiers

        /// <summary>
        ///     Adds an amount to the data value.
        /// </summary>
        /// <param name="value"></param>
        public void AddTo(float value)
        {
            Value += value;
        }

        /// <summary>
        ///     Subtracts an amount from the data value.
        /// </summary>
        /// <param name="value"></param>
        public void SubtractFrom(float value)
        {
            Value -= value;
        }

        /// <summary>
        ///     Multiplies an amount to the data value.
        /// </summary>
        /// <param name="value"></param>
        public void MultiplyWith(float value)
        {
            Value *= value;
        }

        /// <summary>
        ///     Divides the data value by an amount.
        /// </summary>
        /// <param name="value"></param>
        public void DivideBy(float value)
        {
            Value /= value;
        }

        #endregion

        #region Data Modifiers

        /// <summary>
        ///     Adds an amount to the data value.
        /// </summary>
        /// <param name="value"></param>
        public void AddTo(FloatData value)
        {
            Value += value.Value;
        }

        /// <summary>
        ///     Subtracts an amount from the data value.
        /// </summary>
        /// <param name="value"></param>
        public void SubtractFrom(FloatData value)
        {
            Value -= value.Value;
        }

        /// <summary>
        ///     Multiplies an amount to the data value.
        /// </summary>
        /// <param name="value"></param>
        public void MultiplyWith(FloatData value)
        {
            Value *= value.Value;
        }

        /// <summary>
        ///     Divides the data value by an amount.
        /// </summary>
        /// <param name="value"></param>
        public void DivideBy(FloatData value)
        {
            Value /= value.Value;
        }

        #endregion

        #region Base Comparisons

        /// <summary>
        ///     Checks if the data value is equal to the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Equal(float value)
        {
            return Value.Equals(value);
        }

        /// <summary>
        ///     Checks if the data value is not equal to the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool NotEqual(float value)
        {
            return !Value.Equals(value);
        }

        /// <summary>
        ///     Checks if the data value is greater than the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GreaterThan(float value)
        {
            return Value > value;
        }

        /// <summary>
        ///     Checks if the data value is less than the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool LessThan(float value)
        {
            return Value < value;
        }

        /// <summary>
        ///     Checks if the data value is greater than or equal to the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GreaterThanEqual(float value)
        {
            return Value >= value;
        }

        /// <summary>
        ///     Checks if the data value is less than or equal to the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool LessThanEqual(float value)
        {
            return Value <= value;
        }

        #endregion

        #region Data Comparisons

        /// <summary>
        ///     Checks if the data value is equal to the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Equal(FloatData value)
        {
            return Value.Equals(value.Value);
        }

        /// <summary>
        ///     Checks if the data value is not equal to the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool NotEqual(FloatData value)
        {
            return !Value.Equals(value.Value);
        }

        /// <summary>
        ///     Checks if the data value is greater than the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GreaterThan(FloatData value)
        {
            return Value > value.Value;
        }

        /// <summary>
        ///     Checks if the data value is less than the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool LessThan(FloatData value)
        {
            return Value < value.Value;
        }

        /// <summary>
        ///     Checks if the data value is greater than or equal to the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GreaterThanEqual(FloatData value)
        {
            return Value >= value.Value;
        }

        /// <summary>
        ///     Checks if the data value is less than or equal to the given value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool LessThanEqual(FloatData value)
        {
            return Value <= value.Value;
        }

        #endregion
    }
}