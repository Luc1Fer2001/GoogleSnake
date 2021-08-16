using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private float _tailDistance;
    [SerializeField] private GameObject _tailPrefab;
    [SerializeField] private List<Transform> _tails = new List<Transform>();
    [SerializeField] private float _speed;


    private void Update()
    {
        MoveSnake(transform.position + transform.forward * _speed);

        float angel = Input.GetAxis("Horizontal") * 2;
        transform.Rotate(0, angel, 0);
    }

    private void MoveSnake(Vector3 newPosition)
    {
        transform.position = newPosition;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IFood>(out IFood food))
        {
            GetComponent<Animator>().SetTrigger("Eat");
            food.Collect();
            var tail = Instantiate(_tailPrefab);
            var tailMove = tail.GetComponent<Tail>();
            tailMove.SetParameters(1, _tails[_tails.Count - 1].gameObject);
            _tails.Add(tail.transform);
        }
    }
}
