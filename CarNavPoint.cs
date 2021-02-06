using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNavPoint : MonoBehaviour
{
    CarNavigation navManager;
    [SerializeField] int thisPoint;

    private void Awake()
    {
        navManager = GetComponentInParent<CarNavigation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CarBehaviour _car = other.GetComponent<CarBehaviour>();

        if(_car != null && _car == navManager.car)
        {
            navManager.UpdateCurrentPoint(thisPoint + 1);
        }
    }
}
