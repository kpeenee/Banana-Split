using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    [Header("Player moovement")]
    [SerializeField] float moveSpeed = 5f;

    void Start()
    {
        //Get rigidbody on player
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.forward, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distanceToPlane;

            if(plane.Raycast(ray,out distanceToPlane))
            {
                Debug.Log(ray.GetPoint(distanceToPlane));
            }
        }
    }

    private void FixedUpdate()
    {
        float inputHorizon = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(inputHorizon * moveSpeed, rb.velocity.y, 0);
    }
}
