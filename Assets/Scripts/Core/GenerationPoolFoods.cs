using System.Collections.Generic;
using UnityEngine;

public class GenerationPoolFoods : MonoBehaviour
{
    public static GenerationPoolFoods Instance;

    [SerializeField] private GameObject _defaultFoodPrefab;
    [SerializeField] private GameObject _redFoodPrefab;

    [SerializeField] private int _defaultFoodCount;
    [SerializeField] private int _redFoodCount;

    [SerializeField] private int _poolSize;

    private List<IFood> _foods = new List<IFood>();
    private List<IFood> _destroyedFood = new List<IFood>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        FillPool();
    }

    private void FillPool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            var food = Instantiate(_defaultFoodPrefab);
            food.SetActive(false);
            _foods.Add(food.GetComponent<IFood>());
        }
    }

    public void DestroyFood(GameObject targetFood)
    {
        if (TryGetComponent(out IFood food))
        {
            targetFood.SetActive(false);
            _foods.Remove(food);
            _destroyedFood.Add(food);
        }
    }

}
