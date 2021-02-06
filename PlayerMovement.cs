using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    float jumpForce;
    [SerializeField] float assignedJumpForce, smoothTime;
    public Vector3 move;
    public float moveSpeed;
    public static PlayerMovement Instance;
    bool strafing;
    float moveHorz, moveVert;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this;
        rb = GetComponent<Rigidbody>();
    }
    
    void UpAndDown()
    {
        if (Input.GetAxis("Jump") > 0 && Input.GetAxis("Down") > 0)
        {
            jumpForce = 0;
        }
        else if(Input.GetAxis("Jump") > 0)
        {
            jumpForce = assignedJumpForce;
        }
        else if (Input.GetAxis("Down") > 0)
        {
            jumpForce = -assignedJumpForce;
        }
        else
        {
            jumpForce = 0;
        }
    }

    void Strafing()
    {
        if (Input.GetAxis("Strafe") == 0)
        {
            strafing = false;
        }
        else
        {
            strafing = true;
        }
    }

    void Movement()
    {
        moveHorz = Input.GetAxis("Horizontal");
        moveVert = Input.GetAxis("Vertical");
    }

    void InputListeners()
    {
        UpAndDown();
        Strafing();
        Movement();
    }

    private void Update()
    {
        InputListeners();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 30 && rb.velocity.y > -30)
            rb.AddForce(new Vector3(move.x, jumpForce, move.y));
        
        if (!strafing)
        {
            transform.Rotate(Vector3.up, moveHorz * turnSpeed);
            move = new Vector3(0, move.y, moveVert);
        }
        else
        {
            move = new Vector3(moveHorz, move.y, moveVert);
        }

        rb.AddRelativeForce(move * moveSpeed);
    }

    float lookX, lookY;
    [SerializeField] float lookSens, turnSpeed;
    [SerializeField] GameObject camRotatePoint;

    /*private void LookingAtShit()
    {
        lookX = Input.GetAxisRaw("Mouse X");

        camRotatePoint.transform.rotation *= Quaternion.AngleAxis(lookX * lookSens, Vector3.up);
        //SPAGHETTI
        //https://www.youtube.com/watch?v=KvkUY2LZ5uc
    }*/
}
