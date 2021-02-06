using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : HoldableObject
{
    [SerializeField] CarNavigation navManager;
    [SerializeField] GameObject boxOfDoom;
    Vector3 blindlyDriveTowardsPoint;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
   
        if (navManager != null)
        {
            if (free && navManager.car != null)
            {
                transform.LookAt(blindlyDriveTowardsPoint);
                Drive();
            }
        }
    }

    public void Drive()
    {
        transform.Translate(0, 0, 1);
    }

    public void PointTowards(Vector3 _pos)
    {
        blindlyDriveTowardsPoint = _pos;
    }

    bool passive = false;

    new void OnCollisionEnter(Collision collision)
    {
        NPCbehaviour npc = collision.collider.GetComponent<NPCbehaviour>();

        if (!passive)
        {
            if (collision.collider.GetComponent<HoldableObject>() || npc != null)
            {
                free = false;
                if (navManager != null)
                    navManager.car = null;

                Destroy(boxOfDoom);

                passive = true;
            }
        }
        else
        {
            if (npc != null && collision.relativeVelocity.magnitude > 35)
            {
                npc.Explode();
            }
        }
    }
}
