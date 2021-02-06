using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCbehaviour : MonoBehaviour
{
    [SerializeField] float speed, scaredSpeed;
    Rigidbody rb;
    public bool scared = false, followingPath  = false;
    [SerializeField] GameObject billBoard, mesh, bloodPrefab;

    [SerializeField] bool indestructible;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void MoveForwards()
    {
        rb.AddRelativeForce(new Vector3(0, 0, speed));
        //transform.Translate(new Vector3(0, 0, speed));
    }

    

    void RotateAround()
    {
        float rotationAngle = Random.Range(15, 90);

        if (Random.Range(0, 2) == 1)
            rotationAngle = -rotationAngle;

        transform.Rotate(Vector3.up, rotationAngle);
    }

    private void FixedUpdate()
    {
        if (!scared && !followingPath)
        {
            billBoard.SetActive(false);
            NotScaredRoutine();
        }
        else if (followingPath && !scared)
        {
            billBoard.SetActive(false);
            MoveForwards();
        }
        else
        {
            billBoard.SetActive(true);
            ScaredRoutine();
        }
    }

    void NotScaredRoutine()
    {
        MoveForwards();
        if (Random.Range(0, 20) == 1)
            RotateAround();
    }

    void ScaredRoutine()
    {
        Vector3 lookAtPlayer = new Vector3(
            PlayerMovement.Instance.transform.position.x, //X
            transform.position.y, //Y
            PlayerMovement.Instance.transform.position.z); //Z
        transform.LookAt(lookAtPlayer); //Looks at the player's X and Z axis values, and its own Y value
        
        RunAway();

        if(Vector3.Distance(PlayerMovement.Instance.transform.position, transform.position) >= 50)
        {
            scared = false;
        }
    }

    void RunAway()
    {
        rb.AddRelativeForce(new Vector3(0, 0, -scaredSpeed));
        //transform.Translate(new Vector3(0, 0, -speed));
    }

    public void LookAtPoint(Transform _point)
    {
        if(!scared)
            transform.LookAt(_point.position);
    }

    public void Explode()
    {
        billBoard.SetActive(false);
        mesh.SetActive(false);
        Instantiate(bloodPrefab, transform.position, transform.rotation);
        ScoreKeeper.Instance.UpdateScore();
        Destroy(gameObject);
    }
}
