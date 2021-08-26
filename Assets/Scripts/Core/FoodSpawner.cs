using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class FoodSpawner : MonoBehaviour
    {
        [SerializeField] private float _sizeMapX;
        [SerializeField] private float _sizeMapZ;

        [SerializeField] private int _minTimeToSpawn;
        [SerializeField] private int _maxTimeToSpawn;

        [SerializeField] private List<GameObject> _listFoodsPrefabs = new List<GameObject>();

        private IEnumerator _spawnFood;

        private void Start()
        {
            _spawnFood = TimerToSpawnFood(Random.Range(_minTimeToSpawn, _maxTimeToSpawn));
            StartCoroutine(_spawnFood);
        }

        private IEnumerator TimerToSpawnFood(int secondsToSpawn)
        {
            while (secondsToSpawn > 0)
            {
                yield return new WaitForSeconds(1);
                secondsToSpawn--;
            }
            SpawnNextFood();
        }

        private void SpawnNextFood()
        {
            StopCoroutine(_spawnFood);
            if (_listFoodsPrefabs.Count != 0)
            {
                Instantiate(_listFoodsPrefabs[Random.Range(0, _listFoodsPrefabs.Count)], SpawnPosition(), Quaternion.identity);
            }
            else
            {
                Debug.LogError("List FoodPrefabs not fill");
            }
        }

        private Vector3 SpawnPosition()
        {
            float sizeX = _sizeMapX / 2;
            float sizeZ = _sizeMapZ / 2;
            return new Vector3(Random.Range(-sizeX, sizeX), 0, Random.Range(-sizeZ, sizeZ));
        }
    }
}
