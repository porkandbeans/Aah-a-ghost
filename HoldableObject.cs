using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldableObject : MonoBehaviour
{
    public bool free = true;
    Transform targetPosition;
    Rigidbody rb;
    Color32 originalColour;
    [SerializeField] float moveTowardSpeed;
    [SerializeField] bool indestructible;
    [SerializeField] GameObject particles;
 
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        originalColour = GetComponent<Renderer>().material.color;
    }

    virtual protected void FixedUpdate()
    {
        if (!free && targetPosition != null)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                Vector3 heading = targetPosition.position - transform.position;
                rb.AddForce(heading * moveTowardSpeed);
                transform.rotation = targetPosition.rotation;
            }
            else
            {
                Release();
            }
        }
    }

    public void Glow()
    {
        GetComponent<Renderer>().material.color = new Color32((byte)0, (byte)255, (byte)0, (byte)100);
    }

    public void StopGlowing()
    {
        GetComponent<Renderer>().material.color = originalColour;
    }

    public void Grab(Transform captor)
    {
        targetPosition = captor;
        free = false;
    }

    public void Release()
    {
        free = true;
        targetPosition = null;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude >= 35)
        {
            if (!indestructible)
            {
                Destroy(gameObject);
                Instantiate(particles, transform.position, transform.rotation);
            }
        }
    }
}