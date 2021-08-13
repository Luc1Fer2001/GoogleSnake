using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _target;

    public void SetParameters( float speed, GameObject target)
    {
        _speed = speed;
        _target = target;
    }
    
    private void Update()
    {
        MoveTail();
    }

    private void MoveTail()
    {
        transform.LookAt(_target.transform);
        transform.position = Vector3.Lerp(transform.position, new Vector3(_target.transform.position.x, 0.3f, _target.transform.position.z), Time.deltaTime * _speed);
    }
}
