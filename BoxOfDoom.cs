using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOfDoom : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        NPCbehaviour npc = other.GetComponent<NPCbehaviour>();

        if (npc != null)
            npc.Explode();
    }
}
