using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _target;
    [SerializeField] private float minDist;

    public void SetParameters( float speed, GameObject target)
    {
        _speed = speed;
        _target = target;
    }

    private void Awake()
    {
        transform.position = _target.transform.forward * -minDist;
    }
    
    private void Update()
    {
        MoveTail();
    }

    private void MoveTail()
    {
        transform.LookAt(_target.transform);
        var dist = Vector3.Distance(transform.position, target.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, dist - minDist);
    }
}
