using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneScript : MonoBehaviour
{
    [SerializeField] GameObject blood;
    [SerializeField] Transform bloodTransform;

    private void OnTriggerEnter(Collider other)
    {
        NPCbehaviour npc = other.GetComponent<NPCbehaviour>();

        if(npc != null)
        {
            npc.Explode();
            Instantiate(blood, bloodTransform.position, bloodTransform.rotation);
        }
    }
}
