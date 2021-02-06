using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRadius : MonoBehaviour
{
    NPCbehaviour parent;

    void Awake() => parent = GetComponentInParent<NPCbehaviour>();

    private void OnTriggerStay(Collider other)
    {
        HoldableObject heldObject = other.GetComponent<HoldableObject>();

        if (heldObject != null && !heldObject.free)
            parent.scared = true;
    }
}
