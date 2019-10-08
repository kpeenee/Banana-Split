using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    [Header("Player moovement")]
    [SerializeField] float moveSpeed = 5f;

    [Header("Player Projectile")]
    [SerializeField] float power = 2f;
    [SerializeField] PlayerProjectile projectile;
    [SerializeField] Transform shootPoint;
    private Vector3 startPos;
    private Vector3 endPos;
   

    void Start()
    {
        //Get rigidbody on player
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Get position clicked
            Plane plane = new Plane(Vector3.forward, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distanceToPlane;

            if(plane.Raycast(ray,out distanceToPlane))
            {
                startPos = ray.GetPoint(distanceToPlane);
                Debug.Log(startPos);
            }
        }

        if (Input.GetMouseButton(0))
        {
            endPos = shootPoint.position;
            Debug.Log(endPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Fire(startPos,endPos);
        }
    }

    private void FixedUpdate()
    {
        float inputHorizon = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(inputHorizon * moveSpeed, rb.velocity.y, 0);
    }

    private void Fire(Vector3 start,Vector3 end)
    {
        Vector3 direction = start - end;
        PlayerProjectile playerProjectile = Instantiate(projectile, shootPoint.position, Quaternion.identity) as PlayerProjectile;
        playerProjectile.GetComponent<Rigidbody>().velocity = direction * power;
    }
}
