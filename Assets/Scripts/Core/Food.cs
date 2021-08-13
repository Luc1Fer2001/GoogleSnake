using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private int _scoreCost;

    public void Collect()
    {
        Destroy(gameObject);
    }
}
