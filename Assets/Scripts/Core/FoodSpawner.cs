using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private float _sizeMapX;
    [SerializeField] private float _sizeMapZ;

    [SerializeField] private float _minTimeToSpawn;
    [SerializeField] private float _maxTimeToSpawn;

    private void Start()
    {
    }

    private Vector3 SpawnPosition()
    {
        float sizeX = _sizeMapX / 2;
        float sizeZ = _sizeMapZ / 2;
        return new Vector3(Random.Range(-sizeX, sizeX), 0, Random.Range(-sizeZ, sizeZ));
    }
}
