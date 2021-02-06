using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyCameraStuff : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.RotateAround(PlayerMovement.Instance.transform.position, Vector3.up, 0.1f);
    }
}
