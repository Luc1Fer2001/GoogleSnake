using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private float _tailDistance;
    [SerializeField] private GameObject _tailPrefab;
    [SerializeField] private List<Transform> _tails = new List<Transform>();
    [SerializeField] private float _speed;
    [SerializeField] private Transform _snakeTransform;


    private void Update()
    {
        MoveSnake(_snakeTransform.position + _snakeTransform.forward * _speed);

        float angel = Input.GetAxis("Horizontal") * 4;
        _snakeTransform.Rotate(0, angel, 0);
    }

    private void MoveSnake(Vector3 newPosition)
    {
        float sqrDistance = _tailDistance * _tailDistance;
        Vector3 previousPosition = _snakeTransform.position;

        foreach (var tail in _tails)
        {
            if ((tail.position - previousPosition).sqrMagnitude > sqrDistance)
            {
                var temp = tail.position;
                tail.LookAt(previousPosition);
                tail.position = previousPosition;
                previousPosition = temp;
            }
            else
            {
                break;
            }
        }
        _snakeTransform.position = newPosition;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            GetComponent<Animator>().SetTrigger("Eat");
            Destroy(collision.gameObject);
            Vector3 spawnPosition = _tails[_tails.Count - 1].position;
            var tail = Instantiate(_tailPrefab, spawnPosition, Quaternion.identity);
            _tails.Add(tail.transform);
        }
    }
}
