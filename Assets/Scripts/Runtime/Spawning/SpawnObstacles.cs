using System.Collections;
using UncleUee.Global;
using UnityEngine;

namespace UncleUee.Spawner
{
    public class SpawnObstacles : MonoBehaviour
    {
        #region VARIABLES

        [Header("Game Variables")]
        public Variables Variables;

        [Header("Spawn Properties")]
        public Transform[] SpawnPoints;

        [Header("Obstacles")]
        public Transform ObstaclesParent;
        public GameObject[] ObstaclesPrefabs;

        private int _length1 = 0;
        private int _length2 = 0;

        #endregion

        #region UNITY METHODS

        private void Awake()
        {
            _length1 = ObstaclesPrefabs.Length;
            _length2 = SpawnPoints.Length;
        }

        #endregion

        #region METHODS

        public void StartSpawnAfterTime()
        {
            StopAllCoroutines();
            StartCoroutine(nameof(SpawnAfterTime));
        }

        public IEnumerator SpawnAfterTime()
        {
            DestroyAllObstacles();
            while (Variables.Playing)
            {
                SpawnObstacle();
                yield return new WaitForSeconds(Variables.SpawnDelay);
            }
        }

        public void SpawnObstacle()
        {
            int index1 = Random.Range(0, _length1);
            int index2 = Random.Range(0, _length2);
            Instantiate(ObstaclesPrefabs[index1], SpawnPoints[index2].position, Quaternion.identity, ObstaclesParent);
        }

        public void DestroyAllObstacles()
        {
            foreach (Transform child in ObstaclesParent)
            {
                Destroy(child.gameObject);
            }
        }

        #endregion
    }
}