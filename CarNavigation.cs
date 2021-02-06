using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNavigation : MonoBehaviour
{
    [SerializeField] Transform[] navPoints;
    public CarBehaviour car;

    public int currentPoint;

    private void FixedUpdate()
    {
        if(car != null)
        {
            car.PointTowards(navPoints[currentPoint].position);
        }
    }

    public void UpdateCurrentPoint(int _point)
    {
        currentPoint = _point;

        if(currentPoint >= navPoints.Length)
        {
            currentPoint = 0;
        }
    }
}
