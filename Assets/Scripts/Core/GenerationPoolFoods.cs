using System.Collections.Generic;
using UnityEngine;

public class GenerationPoolFoods : MonoBehaviour
{
    [SerializeField] private GameObject _foodPrefab;

    [SerializeField] private int _poolSize;

    private List<GameObject> _foods = new List<GameObject>();

    private void Awake()
    {
        FillPool();
    }

    private void FillPool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            var food = Instantiate(_foodPrefab);
            food.SetActive(false);
            _foods.Add(food);
        }
    }

}
