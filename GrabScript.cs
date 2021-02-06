using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    bool canGrab = true;

    private void OnTriggerStay(Collider other)
    {
        HoldableObject grabTarget = other.GetComponent<HoldableObject>();
        
        if(grabTarget != null)
        {
            if (grabTarget.free && canGrab)
                grabTarget.Glow();
            else
                grabTarget.StopGlowing();

            if (Input.GetKey(KeyCode.Return))
            {
                if(canGrab)
                    grabTarget.Grab(transform);
                canGrab = false;
            }
            else
            {
                grabTarget.Release();
                canGrab = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HoldableObject grabTarget = other.GetComponent<HoldableObject>();
        if (grabTarget != null)
        {
            grabTarget.StopGlowing();
        }
    }
}
