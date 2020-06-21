using UnityEngine;

namespace UncleUee.Global
{
    [CreateAssetMenu(menuName = "Learning Yogi/Global/Variables")]
    public class Variables : ScriptableObject
    {
        #region VARIABLES

        [Header("Game States")]
        public bool Playing = false;

        [Header("Scrolling Speed")]
        public float GroundSpeedMultiplier = 1f;
        public float IncrementGroundSpeedBy = 0.1f;

        [Header("Spawn Properties")]
        public float SpawnDelay = 1f;
        public float MinSpawnDelay       = 3f;
        public float decrementSpawnDelay = 0.1f;

        [Header("Obstacles Speed")]
        public float ObstacleSpeed = 9.45f;
        public float IncrementObstaclesSpeed = 0.1f;

        [Header("Score")]
        public int Score;
        public int Highscore;

        #endregion

        #region METHODS

        public void SetPlaying(bool value)
        {
            Playing = value;
        }

        public void IncreaseScore(int value)
        {
            Score += value;
        }

        public void IncreaseGroundSpeedMultiplier()
        {
            GroundSpeedMultiplier += IncrementGroundSpeedBy;
        }

        public void DecreaseSpawnDelay()
        {
            SpawnDelay -= decrementSpawnDelay;
            SpawnDelay =  Mathf.Max(MinSpawnDelay, SpawnDelay);
        }

        public void IncreaseObstacleSpeed()
        {
            ObstacleSpeed += IncrementObstaclesSpeed;
        }

        public void ResetGroundSpeedMultiplier(float value)
        {
            GroundSpeedMultiplier = value;
        }

        public void ResetObstacleSpeed(float value)
        {
            ObstacleSpeed = value;
        }

        public void ResetSpawnDelay(float value)
        {
            SpawnDelay = value;
        }

        #endregion
    }
}