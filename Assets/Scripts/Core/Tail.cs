using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _minDist;

    public void SetParameters( float speed, GameObject target)
    {
        _target = target;
        transform.position = _target.transform.forward * -_minDist;
    }
    
    private void Update()
    {
        MoveTail();
    }

    private void MoveTail()
    {
        transform.LookAt(_target.transform);
        var dist = Vector3.Distance(transform.position, _target.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, dist - _minDist);
    }
}
