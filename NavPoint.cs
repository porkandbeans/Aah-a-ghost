using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavPoint : MonoBehaviour
{
    NavigateNPC navManager;

    private void Awake()
    {
        navManager = GetComponentInParent<NavigateNPC>();
    }

    private void OnTriggerEnter(Collider other)
    {
        NPCbehaviour npc = other.GetComponent<NPCbehaviour>();

        if (npc != null && npc == navManager.npc)
            navManager.ReachedPoint();
    }
}
